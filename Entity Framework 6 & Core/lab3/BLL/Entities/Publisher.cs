using System;

namespace BLL.Entities
{
    public class Publisher : EntityBase
    {
        public Publisher()
        {
            State = EntityState.Added;
        }

        private string _pubID;
        public string PubID
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

        private string _pubName;
        public string PubName
        {
            get => _pubName;
            set
            {
                if (_pubName != value)
                {
                    _pubName = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private string? _city;
        public string? City
        {
            get => _city;
            set
            {
                if (_city != value)
                {
                    _city = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private string? _stateName;
        public string? StateName
        {
            get => _stateName;
            set
            {
                if (_stateName != value)
                {
                    _stateName = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private string? _country;
        public string? Country
        {
            get => _country;
            set
            {
                if (_country != value)
                {
                    _country = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }
    }
}