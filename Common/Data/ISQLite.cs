﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
