namespace AllyInvestApi {
	public interface IApi {
		public Dictionary<String,String> Headers {get;set;}
	}
	public static class DateTimeExtensions {
		static readonly DateTime EpochStart = new DateTime(1970, 1, 1);
		public static String ToEpoch(this DateTime val) => (val - EpochStart)*86400;
	}
	public static class IEnumerableExtensions {
		public void ForEach<T>(this IEnumerable<T> items, Action<T> task) {
			foreach(var item in items) task(item);
		}
	}
	public class ApiOptions {
		public static IEnumerable<MemberInfo> Members = typeof(ApiOptions).GetMembers().ToEnumerable();
		public ApiOptions() {}
		public String Authorization {get;set;} = "OAuth";
		public String OAuth_Signature_Method {get;set;} = "HMAC-SHA1";
		public String OAuth_Version {get;set;} = "1.0";
	}
	public class Api : IApi {
		static IEnumerable<MemberInfo> Members = typeof(Api).GetMembers().ToEnumerable();
		public Api(ApiOptions opt = default) {
			Authorization = opt.Authorization;
			OAuth_Signature_Method = opt.OAuth_Signature_Method;
			OAuth_Version = opt.OAuth_Version;
		}
		public Api(String consumerKey, String consumerSecret, String token, String tokenSecret, ApiOptions opt = default) ?: this(opt) {
			OAuth_Consumer_Key = consumerKey;
			OAuth_Consumer_Secret = consumerSecret;
			OAuth_Token = token;
			OAuth_Token_Secret = tokenSecret;
		}
		String Authorization {get;set;}
		String OAuth_Signature_Method {get;set;}
		String OAuth_Version {get;set;}
		
		String OAuth_Consumer_Key {get;set;}
		String OAuth_Consumer_Secret {get;set;}
		String OAuth_Token {get;set;}
		String OAuth_Token_Secret {get;set;}
		
		DateTime ServerTime {get;set;}
		DateTime Time => DateTime.Now;
	}
}