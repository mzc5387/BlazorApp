public interface ITmdbService
{
    Task<MovieSearchResult?> SearchMoviesAsync(string query);
    Task<MovieSearchResult?> GetTopMoviesAsync();
    Task<MovieCredits?> GetMovieCreditsAsync(int movieId);
    Task<TvShowSearchResult?> SearchTvShowsAsync(string query);
    Task<TvShowSearchResult?> GetTopTvShowsAsync();
    Task<TvShowCredits?> GetTvShowCreditsAsync(int tvShowId);
}
