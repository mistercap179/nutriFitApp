using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.Database.Conversions
{
    internal interface IConversion
    {
        Models.Jelo ConvertJelo(Database.Jela model);
        Models.Stavka ConvertStavka(Database.Stavke model);
        Models.Racun ConvertRacun(Database.Racuni model);
        Models.Sok ConvertSok(Database.Sokovi model);
    }
}
