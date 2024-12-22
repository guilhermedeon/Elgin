using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgin.Entities.Enums
{
    public enum ElginModel
    {
        i7,
        i7Plus,
        i8,
        i9,
        ix,
        Fitpos,
        BKT681,
        MP4200,
        MP4200HS,
        MP2800,
    }

    public static class ElginModelsExtensions
    {
        public static string ToString(this ElginModel model)
        {
            return model switch
            {
                ElginModel.i7 => "i7",
                ElginModel.i7Plus => "i7 Plus",
                ElginModel.i8 => "i8",
                ElginModel.i9 => "i9",
                ElginModel.ix => "ix",
                ElginModel.Fitpos => "Fitpos",
                ElginModel.BKT681 => "BK-T681",
                ElginModel.MP4200 => "MP-4200",
                ElginModel.MP4200HS => "MP-4200 HS",
                ElginModel.MP2800 => "MP-2800",
                _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
            };
        }
    }
}
