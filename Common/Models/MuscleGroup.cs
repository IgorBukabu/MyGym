using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace Common.Models
{
    [Table("MuscleGroup")]
    public class MuscleGroup
    {
        private string _muscleGropuName;
        private int _muscleGroupCode;
        private string _exerciseCodes = "";

        #region Properties

        [PrimaryKey, AutoIncrement]
        public int MuscleGroupCode
        {
            get
            {
                return this._muscleGroupCode;
            }
            private set
            {
                this._muscleGroupCode = value;
                OnPropertyChanged(nameof(MuscleGroupCode));
            }
        }

        [NotNull]
        public string MuscleGropuName
        {
            get
            {
                return this._muscleGropuName;
            }
            private set
            {
                this._muscleGropuName = value;
                OnPropertyChanged(nameof(MuscleGropuName));
            }
        }

        public string ExerciseCodes
        {
            get
            {
                return this._exerciseCodes;
            }
            private set
            {
                this._exerciseCodes = value;
                OnPropertyChanged(nameof(ExerciseCodes));
            }
        }

        #endregion

        public MuscleGroup()
        {
        }

        public MuscleGroup(string muscleGroupName)
        {
            MuscleGropuName = muscleGroupName;
        }

        public MuscleGroup(string muscleGroupName, int muscleGroupCode)
        {
            MuscleGropuName = muscleGroupName;
            MuscleGroupCode = muscleGroupCode;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
