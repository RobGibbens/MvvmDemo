using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MonoTouch.UIKit;

namespace MvvmDemo.iOS
{
	public static class Layout
	{
		/// <summary>
		/// <para>Constrains the layout of subviews according to equations and
		/// inequalities specified in <paramref name="constraints"/>.  Issue
		/// multiple constraints per call using the &amp;&amp; operator.</para>
		/// <para>e.g. button.Frame.Left &gt;= text.Frame.Right + 22 &amp;&amp;
		/// button.Frame.Width == View.Frame.Width * 0.42f</para>
		/// </summary>
		/// <param name="view">The superview laying out the referenced subviews.</param>
		/// <param name="constraints">Constraint equations and inequalities.</param>
		public static void ConstrainLayout(this UIView view, Expression<Func<bool>> constraints)
		{
			var body = ((LambdaExpression)constraints).Body;

			var exprs = new List<BinaryExpression>();
			FindConstraints(body, exprs);

			view.AddConstraints(exprs.Select(CompileConstraint).ToArray());
		}

		static NSLayoutConstraint CompileConstraint(BinaryExpression expr)
		{
			var rel = NSLayoutRelation.Equal;
			switch (expr.NodeType)
			{
				case ExpressionType.Equal:
					rel = NSLayoutRelation.Equal;
					break;
				case ExpressionType.LessThanOrEqual:
					rel = NSLayoutRelation.LessThanOrEqual;
					break;
				case ExpressionType.GreaterThanOrEqual:
					rel = NSLayoutRelation.GreaterThanOrEqual;
					break;
				default:
					throw new NotSupportedException("Not a valid relationship for a constrain.");
			}

			var left = GetViewAndAttribute(expr.Left);
			left.Item1.TranslatesAutoresizingMaskIntoConstraints = false;

			var right = GetRight(expr.Right);
			if (right.Item1 != null)
			{
				right.Item1.TranslatesAutoresizingMaskIntoConstraints = false;
			}

			return NSLayoutConstraint.Create(
				left.Item1, left.Item2,
				rel,
				right.Item1, right.Item2,
				right.Item3, right.Item4);
		}

		static Tuple<UIView, NSLayoutAttribute, float, float> GetRight(Expression expr)
		{
			var r = expr;

			UIView view = null;
			NSLayoutAttribute attr = NSLayoutAttribute.NoAttribute;
			var mul = 1.0f;
			var add = 0.0f;
			var pos = true;

			if (r.NodeType == ExpressionType.Add || r.NodeType == ExpressionType.Subtract)
			{
				var rb = (BinaryExpression)r;
				if (rb.Left.NodeType == ExpressionType.Constant)
				{
					add = Convert.ToSingle(Eval(rb.Left));
					if (r.NodeType == ExpressionType.Subtract)
					{
						pos = false;
					}
					r = rb.Right;
				}
				else if (rb.Right.NodeType == ExpressionType.Constant)
				{
					add = Convert.ToSingle(Eval(rb.Right));
					if (r.NodeType == ExpressionType.Subtract)
					{
						add = -add;
					}
					r = rb.Left;
				}
				else
				{
					throw new NotSupportedException("Addition only supports constants.");
				}
			}

			if (r.NodeType == ExpressionType.Multiply)
			{
				var rb = (BinaryExpression)r;
				if (rb.Left.NodeType == ExpressionType.Constant)
				{
					mul = Convert.ToSingle(Eval(rb.Left));
					r = rb.Right;
				}
				else if (rb.Right.NodeType == ExpressionType.Constant)
				{
					mul = Convert.ToSingle(Eval(rb.Right));
					r = rb.Left;
				}
				else
				{
					throw new NotSupportedException("Multiplication only supports constants.");
				}
			}

			if (r.NodeType == ExpressionType.MemberAccess)
			{
				var t = GetViewAndAttribute(r);
				view = t.Item1;
				attr = t.Item2;
			}
			else if (r.NodeType == ExpressionType.Constant)
			{
				add = Convert.ToSingle(Eval(r));
			}
			else
			{
				throw new NotSupportedException("Unknown node type " + r.NodeType);
			}

			if (!pos)
				mul = -mul;

			return Tuple.Create(view, attr, mul, add);
		}

		static Tuple<UIView, NSLayoutAttribute> GetViewAndAttribute(Expression expr)
		{
			var attrExpr = expr as MemberExpression;
			if (attrExpr == null)
				throw new NotSupportedException("Left hand side of a relation must be a simple member expression");

			var attr = NSLayoutAttribute.NoAttribute;
			switch (attrExpr.Member.Name)
			{
				case "Width":
					attr = NSLayoutAttribute.Width;
					break;
				case "Height":
					attr = NSLayoutAttribute.Height;
					break;
				case "Left":
				case "X":
					attr = NSLayoutAttribute.Left;
					break;
				case "Top":
				case "Y":
					attr = NSLayoutAttribute.Top;
					break;
				case "Right":
					attr = NSLayoutAttribute.Right;
					break;
				case "Bottom":
					attr = NSLayoutAttribute.Bottom;
					break;
				default:
					throw new NotSupportedException("Property " + attrExpr.Member.Name + " is not recognized.");
			}

			var frameExpr = attrExpr.Expression as MemberExpression;
			if (frameExpr == null)
				throw new NotSupportedException("Constraints should use the Frame or Bounds property of views.");
			var viewExpr = frameExpr.Expression;

			var view = Eval(viewExpr) as UIView;
			if (view == null)
				throw new NotSupportedException("Constraints only apply to views.");

			return Tuple.Create(view, attr);
		}

		static object Eval(Expression expr)
		{
			if (expr.NodeType == ExpressionType.Constant)
			{
				return ((ConstantExpression)expr).Value;
			}
			else
			{
				return Expression.Lambda(expr).Compile().DynamicInvoke();
			}
		}

		static void FindConstraints(Expression expr, List<BinaryExpression> constraintExprs)
		{
			var b = expr as BinaryExpression;
			if (b == null)
				return;

			if (b.NodeType == ExpressionType.AndAlso)
			{
				FindConstraints(b.Left, constraintExprs);
				FindConstraints(b.Right, constraintExprs);
			}
			else
			{
				constraintExprs.Add(b);
			}
		}
	}
}