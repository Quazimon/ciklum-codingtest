﻿using System;
using System.Collections.Generic;

namespace Qzk.CodingTest.Entities.JustEat
{
    public class Restaurant
    {
        public double Score { get; set; }
        public double DriveDistance { get; set; }
        public bool DriveInfoCalculated { get; set; }
        public DateTime NewnessDate { get; set; }
        public int? DeliveryMenuId { get; set; }
        public DateTime? DeliveryOpeningTime { get; set; }
        public double DeliveryCost { get; set; }
        public double MinimumDeliveryValue { get; set; }
        public int? DeliveryWorkingTimeMinutes { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime OpeningTimeIso { get; set; }
        public bool SendsOnItsWayNotifications { get; set; }
        public double RatingAverage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ScoreMetadata ScoreMetadata { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public List<CuisineType> CuisineTypes { get; set; }
        public string Url { get; set; }
        public bool IsOpenNow { get; set; }
        public bool IsPremier { get; set; }
        public bool IsSponsored { get; set; }
        public bool IsTemporaryBoost { get; set; }
        public int SponsoredPosition { get; set; }
        public bool IsNew { get; set; }
        public bool IsTemporarilyOffline { get; set; }
        public string ReasonWhyTemporarilyOffline { get; set; }
        public string UniqueName { get; set; }
        public bool IsCloseBy { get; set; }
        public bool IsHalal { get; set; }
        public bool IsTestRestaurant { get; set; }
        public int DefaultDisplayRank { get; set; }
        public bool IsOpenNowForDelivery { get; set; }
        public bool IsOpenNowForCollection { get; set; }
        public double RatingStars { get; set; }
        public List<Logo> Logo { get; set; }
        public int NumberOfRatings { get; set; }
        public bool ShowSmiley { get; set; }
        public int SmileyResult { get; set; }
        public string SmileyUrl { get; set; }
        public string SmileyElite { get; set; }
    }
}
