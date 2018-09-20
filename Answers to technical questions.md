1) I spent on this task approximately 6 hours (a few evenings). I would add few things if I have much time:
 - More testing
 - Logging
 Also I think that some builds, documentation, test-cases, should be added in perfect scenario :)

2) C# and .NET features: 
 - Interpolated strings: var urlSuffix = $"restaurants?q={criteria}";
 - DI from box: services.AddSingleton<IRestaurantsQueryService, RestaurantsQueryService>();
 - some things which I not used like out variables, match patterns, etc.
 
3) Some metrics frameworks can be used (AppMetrics, etc) and high-load tests can be configured.

4) Few things that is good in Api get queries:
 - Set number of records to return
 - Set fields to return
 - Append some filters like order, etc

5) 
"Fedir Hredzhuk" : {
	"Age": "24",
	"Working Experience": {
		"Globallogic": "3 years",
		"Smart Business": "1 year",
		"Terrasoft": "1 year"
	},
	"Skills": ".NET, ASP.NET MVC, JavaScript, MS SQL, Dynamics 365",
	"Interests" : "programming, technologies, football, computer games"
}