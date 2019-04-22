using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Messangers {
    public class SmsService {
        const string baseUrl = "https://api.kavenegar.com/v1";
        //const string _apiKey = "6D7132574B6A733962323452487647523450536A4B422F51457865395A626879";
        public string _ApiKey { get; private set; }
        ////"44564A6A6D4D3958492F4E64756766312B75664C5A776662754B6D5970794158";
        public SmsService (string apiKey) {
            _ApiKey = apiKey;

        }
        public async Task<ResultModel> Send (RequestModel parameters) {
            using (var client = new HttpClient ()) {
                var stringBuilder = new StringBuilder ();

                //BaseUrl & _APIKEY
                stringBuilder.Append ($"{baseUrl}/{_ApiKey}/sms/send.json?");

                //Receptors
                var receptors = String.Join (',', parameters.receptor);
                stringBuilder.Append ($"receptor={receptors}");

                //Message
                var messages = String.Join (',', parameters.message);
                stringBuilder.Append ($"&message={messages}");

                //LocalIds
                var _localids = "";
                if (parameters.localid != null) {
                    _localids = String.Join (',', parameters.localid);
                    stringBuilder.Append ($"&localid={_localids}");
                }

                //Date
                int? _date = null;
                if (parameters.date != default (Int32)) {
                    _date = parameters.date;
                    stringBuilder.Append ($"&date={_date}");
                }

                //Sender
                stringBuilder.Append ($"&sender={parameters.sender[0]}");

                var url = new Uri (stringBuilder.ToString ());

                var response = await client.GetAsync (url);

                string json;
                using (var content = response.Content) {
                    json = await content.ReadAsStringAsync ();
                }

                return JsonConvert.DeserializeObject<ResultModel> (json);

            }
        }

        public async Task<ResultModel> SendArray (RequestModel parameters) {
            using (var client = new HttpClient ()) {
                var url = $"{baseUrl}/{_ApiKey}/sms/sendarray.json";

                var _params = new Dictionary<string, string> { { "receptor", JsonConvert.SerializeObject (parameters.receptor) },
                        { "sender", JsonConvert.SerializeObject (parameters.sender) },
                        { "message", JsonConvert.SerializeObject (parameters.message) },
                    };
                var encodedContent = new FormUrlEncodedContent (_params);

                var response = await client.PostAsync (url, encodedContent);

                string json;

                using (var _content = response.Content) {
                    json = await _content.ReadAsStringAsync ();
                }

                return JsonConvert.DeserializeObject<ResultModel> (json);

            }
        }

        public async Task<ResultModel> Status (Int64[] messageid) {
            var _messageids = string.Join (",", messageid);

            using (var client = new HttpClient ()) {
                var url = new Uri ($"{baseUrl}/{_ApiKey}/sms/status.json?messageid={_messageids}");

                var response = await client.GetAsync (url);

                string json;
                using (var _content = response.Content) {
                    json = await _content.ReadAsStringAsync ();
                }

                return JsonConvert.DeserializeObject<ResultModel> (json);

            }
        }

        public async Task<ResultModel> StatusLocalMessageId (long localMessageid) {
            using (var client = new HttpClient ()) {
                var url = new Uri ($"{baseUrl}/{_ApiKey}/sms/statuslocalmessageid.json?localid={localMessageid}");

                var response = await client.GetAsync (url);

                string json;
                using (var _content = response.Content) {
                    json = await _content.ReadAsStringAsync ();
                }

                return JsonConvert.DeserializeObject<ResultModel> (json);

            }
        }

        public async Task<ResultModel> Recieve (RequestModel parameters) {
            using (var client = new HttpClient ()) {
                var url = new Uri ($"{baseUrl}/{_ApiKey}/sms/receive.json?linenumber={parameters.linenumber}&isread={parameters.isread}");

                var response = await client.GetAsync (url);

                string json;

                using (var _content = response.Content) {
                    json = await _content.ReadAsStringAsync ();
                }

                return JsonConvert.DeserializeObject<ResultModel> (json);

            }
        }

    }
}