using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using System.Net.Http;
using MvvmDemo.Core.Dtos;

namespace MvvmDemo.Core.ViewModels
{
	public class ConferencesViewModel : MvxViewModel
	{
		private readonly IMvxJsonConverter _converter;

		public ConferencesViewModel(IMvxJsonConverter converter)
		{
			_converter = converter;
			Task.WhenAll(Task.Run(() => GetConferences()));
		}

		public async void GetConferences()
		{
			const string url = "http://api.tekconf.com/v1/conferences?format=json";
			var client = new HttpClient();
			const HttpCompletionOption cancellationToken = new HttpCompletionOption();
			var response = await client.GetAsync(url, cancellationToken);
			var responseString = await response.Content.ReadAsStringAsync();

			List<ConferenceDto> conferences = null;
			if (!string.IsNullOrWhiteSpace(responseString))
			{
				conferences = _converter.DeserializeObject<List<ConferenceDto>>(responseString);
			}

			Conferences = conferences;
		}

		private List<ConferenceDto> _conferences;
		public List<ConferenceDto> Conferences
		{
			get
			{
				return _conferences;
			}
			set
			{
				_conferences = value;
				RaisePropertyChanged(() => Conferences);
			}
		}
	}

}