using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Velocity_Rent.Map.Controls.ucSuggestionItem;

namespace Velocity_Rent.Map
{
    internal static class SuggestionStorage
    {
        private static readonly string _baseFolder;
        private static readonly string _recentFile;
        private static readonly string _favoritesFile;

        private const int MaxHistory = 10;


        static SuggestionStorage()
        {
            _baseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Velocity_Rent");
            _recentFile = Path.Combine(_baseFolder, "Recent.json");
            _favoritesFile = Path.Combine(_baseFolder, "Favorite.json");
        }

        private static List<SuggestionItem> LoadFromFile(string path)
        {
            try
            {
                if (!File.Exists(path)) return new List<SuggestionItem>();

                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<SuggestionItem>>(json) ?? new List<SuggestionItem>();
            }
            catch
            {
                return new List<SuggestionItem>();
            }
        }
        private static void SaveToFile(string path, List<SuggestionItem> data)
        {
            if (!Directory.Exists(_baseFolder)) Directory.CreateDirectory(_baseFolder);
            File.WriteAllText(path, JsonSerializer.Serialize(data));
        }

        public static List<SuggestionItem> LoadHistory() => LoadFromFile(_recentFile);
        public static List<SuggestionItem> LoadFavorites() => LoadFromFile(_favoritesFile);

        public static void SaveToHistory(SuggestionItem item)
        {
            var history = LoadHistory();

            history.RemoveAll(x => x.Title == item.Title);
            history.Insert(0, Clone(item, SuggestionType.Recent));

            SaveToFile(_recentFile, history.Take(MaxHistory).ToList());
        }

        public static void ToggleFavorite(SuggestionItem item)
        {
            var favorites = LoadFavorites();

            item.IsFavorite = !item.IsFavorite;
            favorites.RemoveAll(x => x.Title == item.Title);

            if (item.IsFavorite) favorites.Add(Clone(item, SuggestionType.Favorite));

            SaveToFile(_favoritesFile, favorites);
        }

        // UI object ≠ Stored object
        private static SuggestionItem Clone(SuggestionItem src,SuggestionType type)
        {
            return new SuggestionItem
            {
                Title = src.Title,
                Subtitle = src.Subtitle,
                Type = type,
                IsFavorite = src.IsFavorite,
                Lat = src.Lat,
                Lon = src.Lon
            };
        }
    }
}
