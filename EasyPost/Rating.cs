﻿using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System; //THIS WILL BE UNNCESSARY ONCE DONE TESTING

namespace EasyPost
{
    public class Rating : Resource
    {
        public Address from_address { get; set; }
        public Address to_address { get; set; }
        public List<Parcel> parcels { get; set; }
        public List<CarrierAccount> carrier_accounts { get; set; }
        public List<Object> ratings { get; set; }

        /// <summary>
        /// Create Rating.
        /// </summary>
        /// <param name="parameters">
        /// dictionary containing parameters to create the shipment with. Valid pairs:
        ///   * {"from_address", Dictionary<string, object>} See Address.Create for a list of valid keys.
        ///   * {"to_address", Dictionary<string, object>} See Address.Create for a list of valid keys.
        ///   * {"parcels", List<Dictionary<string, object>>} See Parcel.Create for list of valid keys.
        ///   * {"carrier_accounts", List<string>} List of CarrierAccount.id to limit rating.
        /// All invalid keys will be ignored.
        /// </param>
        /// <returns>EasyPost.Rating instance.</returns>
        /// <summary>
        public static Rating Create(Dictionary<string, object> parameters) {
            Request request = new Request("rating/v1/rates", Method.POST);
            request.AddBodyJson(parameters);

            return request.ExecuteJson<Rating>();
        }
    }
}
