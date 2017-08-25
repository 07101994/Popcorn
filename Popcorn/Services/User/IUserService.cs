﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Popcorn.Models.Episode;
using Popcorn.Models.Movie;
using Popcorn.Models.Shows;
using Popcorn.Models.Subtitles;
using Popcorn.Models.User;

namespace Popcorn.Services.User
{
    public interface IUserService
    {
        /// <summary>
        /// Get all available languages
        /// </summary>
        /// <returns>All available languages</returns>
        ICollection<Language> GetAvailableLanguages();

        /// <summary>
        /// Get the current language of the application
        /// </summary>
        Task<Language> GetCurrentLanguageAsync();

        /// <summary>
        /// Set the current language of the application
        /// </summary>
        /// <param name="language">Language</param>
        Task SetCurrentLanguageAsync(Language language);

        /// <summary>
        /// Set if movies have been seen or set as favorite
        /// </summary>
        /// <param name="movies">All movies to compute</param>
        Task SyncMovieHistoryAsync(IEnumerable<IMovie> movies);

        /// <summary>
        /// Set if shows have been seen or set as favorite
        /// </summary>
        /// <param name="shows">All movies to compute</param>
        Task SyncShowHistoryAsync(IEnumerable<IShow> shows);

        /// <summary>
        /// Set the movie
        /// </summary>
        /// <param name="movie">Favorite movie</param>
        Task SetMovieAsync(IMovie movie);

        /// <summary>
        /// Set the show
        /// </summary>
        /// <param name="show">Show</param>
        Task SetShowAsync(IShow show);

        /// <summary>
        /// Get seen movies
        /// </summary>
        /// <param name="page">Pagination</param>
        /// <returns>List of ImdbId</returns>
        Task<(IEnumerable<string> movies, IEnumerable<string> allMovies, int nbMovies)> GetSeenMovies(int page);

        /// <summary>
        /// Get seen shows
        /// </summary>
        /// <param name="page">Pagination</param>
        /// <returns>List of ImdbId</returns>
        Task<(IEnumerable<string> shows, IEnumerable<string> allShows, int nbShows)> GetSeenShows(int page);

        /// <summary>
        /// Get favorites movies
        /// </summary>
        /// <param name="page">Pagination</param>
        /// <returns>List of ImdbId</returns>
        Task<(IEnumerable<string> movies, IEnumerable<string> allMovies, int nbMovies)> GetFavoritesMovies(int page);

        /// <summary>
        /// Get favorites shows
        /// </summary>
        /// <param name="page">Pagination</param>
        /// <returns>List of ImdbId</returns>
        Task<(IEnumerable<string> shows, IEnumerable<string> allShows, int nbShows)> GetFavoritesShows(int page);

        Task<Models.User.User> GetUser();

        /// <summary>
        /// Set the download limit
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task SetDownloadLimit(int limit);

        /// <summary>
        /// Set the upload limit
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task SetUploadLimit(int limit);

        /// <summary>
        /// Set default HD quality
        /// </summary>
        /// <param name="hd"></param>
        /// <returns></returns>
        Task SetDefaultHdQuality(bool hd);

        /// <summary>
        /// Set default subtitle language
        /// </summary>
        /// <param name="englishName"></param>
        /// <returns></returns>
        Task SetDefaultSubtitleLanguage(string englishName);

        /// <summary>
        /// Set default subtitle color
        /// </summary>
        /// <returns></returns>
        Task SetDefaultSubtitleColor(string color);

        /// <summary>
        /// Set default subtitle size
        /// </summary>
        /// <returns></returns>
        Task SetDefaultSubtitleSize(SubtitleSize size);
    }
}