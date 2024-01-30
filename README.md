# Refit

Refit is a .NET package used to create type-safe, dynamic, and HTTP-based APIs. 
It enables programmers to create clear, simple code to use RESTful APIs.

## Create Library with Interface

Add NuGet from Refit:
```
  <ItemGroup>
    <PackageReference Include="Refit" Version="7.0.0" />
  </ItemGroup>
```

Add interface with your endpoints:

```
public interface IRefitApi
{
    [Get(ApiEndpoints.WeatherForecast.Get)]
    Task<WeatherForecast[]> GetWeatherForecastAsync();
}
```

## Use Api

Add NuGet from Refit:
```
  <ItemGroup>
	  <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
	  <PackageReference Include="Refit.HttpClientFactory" Version="7.0.0" />
  </ItemGroup>
```

Just use it 😊 like in the RefitApiConsumer project:

```
var services = new ServiceCollection();

// NuGet Refit.HttpClientFactory
services
    .AddHttpClient()
    .AddRefitClient<IRefitApi>()
    .ConfigureHttpClient(x =>
        x.BaseAddress = new Uri("https://localhost:7254"));

var provider = services.BuildServiceProvider();

var weatherForecastApi = provider.GetRequiredService<IRefitApi>();

var weathers = await weatherForecastApi.GetWeatherForecastAsync();
```

# Other example to imagine
```
[Headers("Authorization: Bearer")]
public interface IMoviesApi
{
    [Get(ApiEndpoints.Movies.Get)]
    Task<MovieResponse> GetMovieAsync(string idOrSlug);

    [Get(ApiEndpoints.Movies.GetAll)]
    Task<MoviesResponse> GetMoviesAsync(GetAllMoviesRequest request);
    
    [Post(ApiEndpoints.Movies.Create)]
    Task<MovieResponse> CreateMovieAsync(CreateMovieRequest request);
    
    [Put(ApiEndpoints.Movies.Update)]
    Task<MovieResponse> UpdateMovieAsync(Guid id, UpdateMovieRequest request);
    
    [Delete(ApiEndpoints.Movies.Delete)]
    Task DeleteMovieAsync(Guid id);

    [Put(ApiEndpoints.Movies.Rate)]
    Task RateMovieAsync(Guid id, RateMovieRequest request);
    
    [Delete(ApiEndpoints.Movies.DeleteRating)]
    Task DeleteRatingAsync(Guid id);

    [Get(ApiEndpoints.Ratings.GetUserRatings)]
    Task<IEnumerable<MovieRatingResponse>> GetUserRatingsAsync();
}

```

