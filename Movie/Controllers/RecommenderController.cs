using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommenderController : ControllerBase
    {
        private readonly MovieDbContext _movieDbContext;

        public RecommenderController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        //[HttpGet]
        //[Route("GetRecommender/{id}")]
        //public async Task<IEnumerable<int[]>> GetUsers()
        //{
        //    int[,] recommenderArray = new int[3, 20];

        //    var recommenderData = await _movieDbContext.Recommenders
        //                                        .OrderBy(r => r.UserId)
        //                                        .ToListAsync();

        //    int row = 0;
        //    int column = 0;
        //    int currentUserId = recommenderData[0].UserId;
        //    foreach (var recommender in recommenderData)
        //    {
        //        if (recommender.UserId != currentUserId)
        //        {
        //            row++;
        //            column = 0;
        //            currentUserId = recommender.UserId;
        //        }

        //        recommenderArray[row, column] = recommender.Rating;
        //        column++;
        //    }

        //    return recommenderArray;
        //}

        //[HttpGet]
        //[Route("GetRecommender/{id}")]
        //public async Task<IEnumerable<Recommender>> GetUsers()
        //{
        //    var result = new Dictionary<string, List<double>>();
        //    result["row1"] = Recommenders.Where(r => r.UserId == 1).Select(r => r.Rating).Take(1).ToList();
        //    result["row2"] = Recommenders.Where(r => r.UserId == 2).Select(r => r.Rating).Take(1).ToList();
        //    result["row3"] = Recommenders.Where(r => r.UserId == 3).Select(r => r.Rating).Take(1).ToList();
        //    return result;
        //}

        //[HttpGet]
        //[Route("GetRecommender")]
        //public async Task<IEnumerable<Recommender>> GetRecommenders()
        //{
        //    return await _movieDbContext.Recommenders.ToListAsync();
        //}

        //[HttpPost]
        //[Route("SendMovieId")]
        //public async Task<Recommender> AddUser(User objUser)
        //{
        //    _movieDbContext.Users.Add(objUser);
        //    await _movieDbContext.SaveChangesAsync();
        //    return objUser;
        //}

        //THIS IS THE ORIGINAL 

        [HttpGet]
        [Route("GetRecommender/{id}")]
        public IActionResult GetRatings(int id)
        {
            var rating = _movieDbContext.Recommenders
                .OrderBy(r => r.UserId)
                .ThenBy(r => r.MovieId)
                .Select(r => r.Rating)
                .ToList();

            if (rating.Count() == 0)
            {
                return NotFound("Movie Id not found");
            }

            var ratings = Enumerable.Range(0, 3)
                .Select(i => rating.Skip(i * 20).Take(20).ToArray())
                .ToArray();

            var ids = _movieDbContext.Recommenders
                .OrderBy(r => r.UserId)
                .ThenBy(r => r.MovieId)
                .Select(r => r.MovieId)
                .Distinct()
                .ToList();

            int movieIndex = ids.FindIndex(i => i == id);
            int[] selectedMovie = ratings[movieIndex];

            double[] similarityScores = new double[3];
            for (int i = 0; i < 3; i++)
            {
                similarityScores[i] = CosineSimilarity(selectedMovie, ratings[i]);
            }

            var similarity = ids.Zip(similarityScores, (k, v) => new { k, v })
                .OrderByDescending(x => x.v)
                .Take(4)
                .Select(x => new { MovieId = x.k, SimilarityScore = x.v });

            return Ok(similarity);
        }

        private static double CosineSimilarity(int[] movie1, int[] movie2)
        {
            double dotProduct = 0.0;
            double magnitude1 = 0.0;
            double magnitude2 = 0.0;
            double cosineSimilarity = 0.0;
            for (int i = 0; i < movie1.Length; i++)
            {
                dotProduct += movie1[i] * movie2[i];
                magnitude1 += Math.Pow(movie1[i], 2);
                magnitude2 += Math.Pow(movie2[i], 2);
            }

            magnitude1 = Math.Sqrt(magnitude1);
            magnitude2 = Math.Sqrt(magnitude2);

            if (magnitude1 != 0.0 | magnitude2 != 0.0)
            {
                cosineSimilarity = dotProduct / (magnitude1 * magnitude2);
            }
            else
            {
                return 0.0;
            }

            return cosineSimilarity;
        }

        //[HttpGet]
        //[Route("GetRecommender/{MovieId}")]
        //public IActionResult GetRecommeder(int MovieId)
        //{
        //    var data = _movieDbContext.Recommenders
        //.OrderBy(r => r.UserId)
        //.ThenBy(r => r.MovieId)
        //.ToList();

        //    int[,] ratings = new int[3, 20];
        //    int userIndex = 0;
        //    int movieIndex = 0;
        //    foreach (var item in data)
        //    {
        //        ratings[userIndex, movieIndex] = item.Rating;
        //        movieIndex++;
        //        if (movieIndex == 20)
        //        {
        //            movieIndex = 0;
        //            userIndex++;
        //        }
        //    }

        //    int users = ratings.GetLength(0);
        //    double[,] similarity = new double[20, 20];

        //    for (int i = 0; i < 20; i++)
        //    {
        //        for (int j = 0; j < 20; j++)
        //        {
        //            if (i == j)
        //            {
        //                similarity[i, j] = 1.0;
        //            }
        //            else
        //            {
        //                int sum = 0;
        //                for (int k = 0; k < users; k++)
        //                {
        //                    sum += ratings[k, i] * ratings[k, j];
        //                }
        //                similarity[i, j] = sum / (Math.Sqrt(ratings[0, i]) * Math.Sqrt(ratings[0, j]));
        //            }
        //        }
        //    }

        //    int movieIndexInSimilarityMatrix = MovieId - 1;
        //    Dictionary<double, int> similarMovies = new Dictionary<double, int>();
        //    for (int j = 0; j < 20; j++)
        //    {
        //        if (j != movieIndexInSimilarityMatrix)
        //        {
        //            similarMovies.Add(similarity[movieIndexInSimilarityMatrix, j], j + 1);
        //        }
        //    }

        //    var sortedMovies = similarMovies.OrderByDescending(x => x.Key);
        //    int[] movieIds = new int[4];
        //    int index = 0;
        //    foreach (var item in sortedMovies)
        //    {
        //        if (index == 4)
        //        {
        //            break;
        //        }
        //        movieIds[index] = item.Value;
        //        index++;
        //    }

        //    return Ok(movieIds);
        //}
    }
}
