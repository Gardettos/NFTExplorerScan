using System;
namespace NFTExplorerScan.Models
{
    public class CollectionStats
    {
        private string _collectionName;
        private string _items;
        private string _floorPrice;
        private string _totalVolume;
        private DateTime _scrapedTime;

        public CollectionStats(string collectionName, string items, string floorPrice, string totalVolume, DateTime scrapedTime)
        {
            _collectionName = collectionName;
            _items = items.Replace("items", "");
            _items.Trim();
            _floorPrice = floorPrice.Replace("floor price", "");
            _floorPrice.Trim();
            _totalVolume = totalVolume.Replace("total volume", "");
            _totalVolume.Trim();
            _scrapedTime = scrapedTime;
        }

        public string CollectionName
        {
            get => _collectionName;
        }

        public string Items
        {
            get => _items;
        }

        public string FloorPrice
        {
            get => _floorPrice;
        }

        public string TotalVolume
        {
            get => _totalVolume;
        }

        public DateTime ScrapeTime
        {
            get => _scrapedTime;
        }
    }
}
