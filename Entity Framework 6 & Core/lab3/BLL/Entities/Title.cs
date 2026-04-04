using System;

namespace BLL.Entities
{
    public class Title : EntityBase
    {
        public Title()
        {
            State = EntityState.Added;
            PubDate = DateTime.Today;
        }

        private string _titleID = string.Empty;
        public string TitleID
        {
            get => _titleID;
            set
            {
                if (_titleID != value)
                {
                    _titleID = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private string _titleName = string.Empty;
        public string TitleName
        {
            get => _titleName;
            set
            {
                if (_titleName != value)
                {
                    _titleName = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private string _type = string.Empty;
        public string Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private string? _pubID;
        public string? PubID
        {
            get => _pubID;
            set
            {
                if (_pubID != value)
                {
                    _pubID = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private decimal? _price;
        public decimal? Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private decimal? _advance;
        public decimal? Advance
        {
            get => _advance;
            set
            {
                if (_advance != value)
                {
                    _advance = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private int? _royalty;
        public int? Royalty
        {
            get => _royalty;
            set
            {
                if (_royalty != value)
                {
                    _royalty = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private int? _ytdSales;
        public int? YTDSales
        {
            get => _ytdSales;
            set
            {
                if (_ytdSales != value)
                {
                    _ytdSales = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private string? _notes;
        public string? Notes
        {
            get => _notes;
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private DateTime? _pubDate;
        public DateTime? PubDate
        {
            get => _pubDate;
            set
            {
                if (_pubDate != value)
                {
                    _pubDate = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }
    }
}