using SQLite;
using System;
using System.ComponentModel;

namespace Common
{
    [Table("TriningPlan")]
    public class TrainingPlan : INotifyPropertyChanged
    {
        #region DM

        private string _trainingPlanName;
        private int _trainingPlanCode;       

        #endregion

        #region Properties

        [PrimaryKey, AutoIncrement]
        public int TrainingPlanCode
        {
            get
            {
                return this._trainingPlanCode;
            }
            private set
            {
                this._trainingPlanCode = value;
                OnPropertyChanged(nameof(TrainingPlanCode));
            }
        }

        [NotNull]
        public string TrainingPlanName
        {
            get
            {
                return this._trainingPlanName;
            }
            private set
            {
                this._trainingPlanName = value;
                OnPropertyChanged(nameof(TrainingPlanName));
            }
        }

        #endregion

        public TrainingPlan()
        {            
        }

        public TrainingPlan(string planName)
        {            
            TrainingPlanName = planName;
        }

        public TrainingPlan(string planName, int TrainingPlanCode2)
        {
            TrainingPlanName = planName;
            this.TrainingPlanCode = TrainingPlanCode2;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
