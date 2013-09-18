<<<<<<< HEAD
﻿
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> b3256fe8e5e0b7e4938975d4c2ac3a5fd79ad1ac
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
<<<<<<< HEAD
			List<ConferenceDto> conferences = null;
			if (!string.IsNullOrWhiteSpace(responseString))
			{
				conferences = _converter.DeserializeObject<List<ConferenceDto>>(responseString);
=======
			List<FullConferenceDto> conferences = null;
			if (!string.IsNullOrWhiteSpace(responseString))
			{
				conferences = _converter.DeserializeObject<List<FullConferenceDto>>(responseString);
>>>>>>> b3256fe8e5e0b7e4938975d4c2ac3a5fd79ad1ac
			}

			Conferences = conferences;
		}

<<<<<<< HEAD
		private List<ConferenceDto> _conferences;
		public List<ConferenceDto> Conferences
=======
		private List<FullConferenceDto> _conferences; 
		public List<FullConferenceDto> Conferences
>>>>>>> b3256fe8e5e0b7e4938975d4c2ac3a5fd79ad1ac
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
<<<<<<< HEAD
		}
	}

}
=======
		} 
	}

}
>>>>>>> b3256fe8e5e0b7e4938975d4c2ac3a5fd79ad1ac
