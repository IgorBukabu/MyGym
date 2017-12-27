using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace Common.Models
{
    [Table("Train")]
    public class Train : INotifyPropertyChanged
    {
        private string _trainName;
        private int _trainCode;
        private string _trainMusclesGroupCodes = "";

        #region Properties

        [PrimaryKey, AutoIncrement]
        public int TrainingCode
        {
            get
            {
                return this._trainCode;
            }
            private set
            {
                this._trainCode = value;
                OnPropertyChanged(nameof(TrainingCode));
            }
        }        

        [NotNull]
        public string TrainingName
        {
            get
            {
                return this._trainName;
            }
            private set
            {
                this._trainName = value;
                OnPropertyChanged(nameof(TrainingName));
            }
        }

        public string TrainMusclesGroupCodes
        {
            get
            {
                return this._trainMusclesGroupCodes;
            }
            private set
            {
                this._trainMusclesGroupCodes = value;
                OnPropertyChanged(nameof(TrainingName));
            }
        }

        #endregion

        public Train()
        {
        }

        public Train(string planName)
        {
            TrainingName = planName;
        }

        public Train(string planName, int TrainingCode2)
        {
            TrainingName = planName;
            this.TrainingCode = TrainingCode2;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
