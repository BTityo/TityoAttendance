﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using TityoAttendance.TityoAttendance.TityoAddress;

namespace TityoAttendance.EntityFrameworkCore.Seed.TityoAttendance
{
    public class DefaultCountryCreator
    {
        private readonly TityoAttendanceDbContext _context;

        public DefaultCountryCreator(TityoAttendanceDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            // Countries
            AddCountryIfNotExists("Afganisztán", "AF");
            AddCountryIfNotExists("Aland-szigetek ", "AX");
            AddCountryIfNotExists("Albánia", "AL");
            AddCountryIfNotExists("Algéria", "DZ");
            AddCountryIfNotExists("Amerikai Szamoa ", "AS");
            AddCountryIfNotExists("Amerikai Virgin-szigetek ", "VI");
            AddCountryIfNotExists("Andorra", "AD");
            AddCountryIfNotExists("Angola", "AO");
            AddCountryIfNotExists("Anguilla ", "AI");
            AddCountryIfNotExists("Antarktisz", "AQ");
            AddCountryIfNotExists("Antigua és Barbuda", "AG");
            AddCountryIfNotExists("Apostoli Szentszék", "VA");
            AddCountryIfNotExists("Argentína", "AR");
            AddCountryIfNotExists("Aruba ", "AW");
            AddCountryIfNotExists("Ausztrália", "AU");
            AddCountryIfNotExists("Ausztria", "AT");
            AddCountryIfNotExists("Az Amerikai Egyesült Államok Külső Szigetei", "UM");
            AddCountryIfNotExists("Azerbajdzsán", "AZ");
            AddCountryIfNotExists("Bahama-szigetek", "BS");
            AddCountryIfNotExists("Bahrein", "BH");
            AddCountryIfNotExists("Banglades", "BD");
            AddCountryIfNotExists("Barbados", "BB");
            AddCountryIfNotExists("Belarusz / Fehéroroszország", "BY");
            AddCountryIfNotExists("Belgium", "BE");
            AddCountryIfNotExists("Belize", "BZ");
            AddCountryIfNotExists("Benin", "BJ");
            AddCountryIfNotExists("Bermuda ", "BM");
            AddCountryIfNotExists("Bhután", "BT");
            AddCountryIfNotExists("Bissau-Guinea", "GW");
            AddCountryIfNotExists("Bolívia", "BO");
            AddCountryIfNotExists("Bosznia-Hercegovina", "BA");
            AddCountryIfNotExists("Botswana", "BW");
            AddCountryIfNotExists("Bouvet-sziget ", "BV");
            AddCountryIfNotExists("Brazília", "BR");
            AddCountryIfNotExists("Brit Indiai-óceáni Terület", "IO");
            AddCountryIfNotExists("Brit Virgin-szigetek ", "VG");
            AddCountryIfNotExists("Brunei", "BN");
            AddCountryIfNotExists("Bulgária", "BG");
            AddCountryIfNotExists("Burkina Faso", "BF");
            AddCountryIfNotExists("Burundi", "BI");
            AddCountryIfNotExists("Chile", "CL");
            AddCountryIfNotExists("Ciprus", "CY");
            AddCountryIfNotExists("Clipperton ", "CP");
            AddCountryIfNotExists("Comore-szigetek", "KM");
            AddCountryIfNotExists("Cook-szigetek ", "CK");
            AddCountryIfNotExists("Costa Rica", "CR");
            AddCountryIfNotExists("Csád", "TD");
            AddCountryIfNotExists("Csehország", "CZ");
            AddCountryIfNotExists("Dánia", "DK");
            AddCountryIfNotExists("Dél-Afrika", "ZA");
            AddCountryIfNotExists("Dél-Georgia és Déli-Sandwich-szigetek ", "GS");
            AddCountryIfNotExists("Dél-Korea", "KR");
            AddCountryIfNotExists("Dominika", "DM");
            AddCountryIfNotExists("Dominikai Köztársaság", "DO");
            AddCountryIfNotExists("Dzsibuti", "DJ");
            AddCountryIfNotExists("Ecuador", "EC");
            AddCountryIfNotExists("Egyenlítői-Guinea", "GQ");
            AddCountryIfNotExists("Egyesült Államok", "US");
            AddCountryIfNotExists("Egyesült Arab Emírségek", "AE");
            AddCountryIfNotExists("Egyesült Királyság", "UK");
            AddCountryIfNotExists("Egyiptom", "EG");
            AddCountryIfNotExists("Elefántcsontpart", "CI");
            AddCountryIfNotExists("Eritrea", "ER");
            AddCountryIfNotExists("Északi-Mariana-szigetek ", "MP");
            AddCountryIfNotExists("Észak-Korea", "KP");
            AddCountryIfNotExists("Észtország", "EE");
            AddCountryIfNotExists("Etiópia", "ET");
            AddCountryIfNotExists("Falkland-szigetek", "FK");
            AddCountryIfNotExists("Feröer szigetek ", "FO");
            AddCountryIfNotExists("Fidzsi-szigetek", "FJ");
            AddCountryIfNotExists("Finnország", "FI");
            AddCountryIfNotExists("Francia Déli Területek ", "TF");
            AddCountryIfNotExists("Francia Guyana ", "GF");
            AddCountryIfNotExists("Francia Polinézia ", "PF");
            AddCountryIfNotExists("Franciaország", "FR");
            AddCountryIfNotExists("Fülöp-szigetek", "PH");
            AddCountryIfNotExists("Gabon", "GA");
            AddCountryIfNotExists("Gambia", "GM");
            AddCountryIfNotExists("Ghána", "GH");
            AddCountryIfNotExists("Gibraltár ", "GI");
            AddCountryIfNotExists("Görögország", "EL");
            AddCountryIfNotExists("Grenada", "GD");
            AddCountryIfNotExists("Grönland ", "GL");
            AddCountryIfNotExists("Grúzia", "GE");
            AddCountryIfNotExists("Guadeloupe ", "GP");
            AddCountryIfNotExists("Guam ", "GU");
            AddCountryIfNotExists("Guatemala", "GT");
            AddCountryIfNotExists("Guinea", "GN");
            AddCountryIfNotExists("Guyana", "GY");
            AddCountryIfNotExists("Haiti", "HT");
            AddCountryIfNotExists("Heard-sziget és McDonald-szigetek ", "HM");
            AddCountryIfNotExists("Holland Antillák ", "AN");
            AddCountryIfNotExists("Hollandia", "NL");
            AddCountryIfNotExists("Honduras", "HN");
            AddCountryIfNotExists("Hongkong ", "HK");
            AddCountryIfNotExists("Horvátország", "HR");
            AddCountryIfNotExists("India", "IN");
            AddCountryIfNotExists("Indonézia", "ID");
            AddCountryIfNotExists("Irak", "IQ");
            AddCountryIfNotExists("Irán", "IR");
            AddCountryIfNotExists("Írország", "IE");
            AddCountryIfNotExists("Izland", "IS");
            AddCountryIfNotExists("Izrael", "IL");
            AddCountryIfNotExists("Jamaica", "JM");
            AddCountryIfNotExists("Japán", "JP");
            AddCountryIfNotExists("Jemen", "YE");
            AddCountryIfNotExists("Jordánia", "JO");
            AddCountryIfNotExists("Kajmán-szigetek ", "KY");
            AddCountryIfNotExists("Kambodzsa", "KH");
            AddCountryIfNotExists("Kamerun", "CM");
            AddCountryIfNotExists("Kanada", "CA");
            AddCountryIfNotExists("Karácsony-sziget ", "CX");
            AddCountryIfNotExists("Katar", "QA");
            AddCountryIfNotExists("Kazahsztán", "KZ");
            AddCountryIfNotExists("Kelet-Timor", "TL");
            AddCountryIfNotExists("Kenya", "KE");
            AddCountryIfNotExists("Kína", "CN");
            AddCountryIfNotExists("Kirgizisztán", "KG");
            AddCountryIfNotExists("Kiribati", "KI");
            AddCountryIfNotExists("Kókusz-szigetek/Keeling-szigetek", "CC");
            AddCountryIfNotExists("Kolumbia", "CO");
            AddCountryIfNotExists("Kongó", "CG");
            AddCountryIfNotExists("Kongói Demokratikus Köztársaság", "CD");
            AddCountryIfNotExists("Közép-afrikai Köztársaság", "CF");
            AddCountryIfNotExists("Kuba", "CU");
            AddCountryIfNotExists("Kuvait", "KW");
            AddCountryIfNotExists("Laosz", "LA");
            AddCountryIfNotExists("Lengyelország", "PL");
            AddCountryIfNotExists("Lesotho", "LS");
            AddCountryIfNotExists("Lettország", "LV");
            AddCountryIfNotExists("Libanon", "LB");
            AddCountryIfNotExists("Libéria", "LR");
            AddCountryIfNotExists("Líbia", "LY");
            AddCountryIfNotExists("Liechtenstein", "LI");
            AddCountryIfNotExists("Litvánia", "LT");
            AddCountryIfNotExists("Luxemburg", "LU");
            AddCountryIfNotExists("Macedónia", "MK");
            AddCountryIfNotExists("Madagaszkár", "MG");
            AddCountryIfNotExists("Magyarország", "HU");
            AddCountryIfNotExists("Makaó ", "MO");
            AddCountryIfNotExists("Malajzia", "MY");
            AddCountryIfNotExists("Malawi", "MW");
            AddCountryIfNotExists("Maldív-szigetek", "MV");
            AddCountryIfNotExists("Mali", "ML");
            AddCountryIfNotExists("Málta", "MT");
            AddCountryIfNotExists("Marokkó", "MA");
            AddCountryIfNotExists("Marshall-szigetek", "MH");
            AddCountryIfNotExists("Martinique ", "MQ");
            AddCountryIfNotExists("Mauritánia", "MR");
            AddCountryIfNotExists("Mauritius", "MU");
            AddCountryIfNotExists("Mayotte ", "YT");
            AddCountryIfNotExists("Mexikó", "MX");
            AddCountryIfNotExists("Mianmar ", "MM");
            AddCountryIfNotExists("Mikronézia", "FM");
            AddCountryIfNotExists("Moldova", "MD");
            AddCountryIfNotExists("Monaco", "MC");
            AddCountryIfNotExists("Mongólia", "MN");
            AddCountryIfNotExists("Montenegró", "ME");
            AddCountryIfNotExists("Montserrat ", "MS");
            AddCountryIfNotExists("Mozambik", "MZ");
            AddCountryIfNotExists("Namíbia", "NA");
            AddCountryIfNotExists("Nauru", "NR");
            AddCountryIfNotExists("Németország", "DE");
            AddCountryIfNotExists("Nepál", "NP");
            AddCountryIfNotExists("Nicaragua", "NI");
            AddCountryIfNotExists("Niger", "NE");
            AddCountryIfNotExists("Nigéria", "NG");
            AddCountryIfNotExists("Niue ", "NU");
            AddCountryIfNotExists("Norfolk-sziget ", "NF");
            AddCountryIfNotExists("Norvégia", "NO");
            AddCountryIfNotExists("Nyugat-Szahara ", "EH");
            AddCountryIfNotExists("Olaszország", "IT");
            AddCountryIfNotExists("Omán", "OM");
            AddCountryIfNotExists("Oroszország", "RU");
            AddCountryIfNotExists("Örményország", "AM");
            AddCountryIfNotExists("Pakisztán", "PK");
            AddCountryIfNotExists("Palau", "PW");
            AddCountryIfNotExists("Panama", "PA");
            AddCountryIfNotExists("Pápua Új-Guinea", "PG");
            AddCountryIfNotExists("Paraguay", "PY");
            AddCountryIfNotExists("Peru", "PE");
            AddCountryIfNotExists("Pitcairn-szigetek ", "PN");
            AddCountryIfNotExists("Portugália", "PT");
            AddCountryIfNotExists("Puerto Rico ", "PR");
            AddCountryIfNotExists("Réunion ", "RE");
            AddCountryIfNotExists("Románia", "RO");
            AddCountryIfNotExists("Ruanda", "RW");
            AddCountryIfNotExists("Saint Kitts és Nevis", "KN");
            AddCountryIfNotExists("Saint Lucia", "LC");
            AddCountryIfNotExists("Saint-Pierre és Miquelon", "PM");
            AddCountryIfNotExists("Saint Vincent és Grenadine-szigetek", "VC");
            AddCountryIfNotExists("Salamon-szigetek", "SB");
            AddCountryIfNotExists("Salvador", "SV");
            AddCountryIfNotExists("San Marino", "SM");
            AddCountryIfNotExists("São Tomé és Príncipe", "ST");
            AddCountryIfNotExists("Seychelle-szigetek", "SC");
            AddCountryIfNotExists("Sierra Leone", "SL");
            AddCountryIfNotExists("Spanyolország", "ES");
            AddCountryIfNotExists("Srí Lanka", "LK");
            AddCountryIfNotExists("Suriname", "SR");
            AddCountryIfNotExists("Svájc", "CH");
            AddCountryIfNotExists("Svalbard- és Jan Mayen-szigetek ", "SJ");
            AddCountryIfNotExists("Svédország", "SE");
            AddCountryIfNotExists("Szamoa", "WS");
            AddCountryIfNotExists("Szaúd-Arábia", "SA");
            AddCountryIfNotExists("Szenegál", "SN");
            AddCountryIfNotExists("Szent Ilona ", "SH");
            AddCountryIfNotExists("Szerbia", "RS");
            AddCountryIfNotExists("Szingapúr", "SG");
            AddCountryIfNotExists("Szíria", "SY");
            AddCountryIfNotExists("Szlovákia", "SK");
            AddCountryIfNotExists("Szlovénia", "SI");
            AddCountryIfNotExists("Szomália", "SO");
            AddCountryIfNotExists("Szudán", "SD");
            AddCountryIfNotExists("Szváziföld", "SZ");
            AddCountryIfNotExists("Tádzsikisztán", "TJ");
            AddCountryIfNotExists("Tajvan ", "TW");
            AddCountryIfNotExists("Tanzánia", "TZ");
            AddCountryIfNotExists("Thaiföld", "TH");
            AddCountryIfNotExists("Togo", "TG");
            AddCountryIfNotExists("Tokelau-szigetek ", "TK");
            AddCountryIfNotExists("Tonga", "TO");
            AddCountryIfNotExists("Törökország", "TR");
            AddCountryIfNotExists("Trinidad és Tobago", "TT");
            AddCountryIfNotExists("Tunézia", "TN");
            AddCountryIfNotExists("Turks- és Caicos-szigetek ", "TC");
            AddCountryIfNotExists("Tuvalu", "TV");
            AddCountryIfNotExists("Türkmenisztán", "TM");
            AddCountryIfNotExists("Uganda", "UG");
            AddCountryIfNotExists("Új-Kaledónia ", "NC");
            AddCountryIfNotExists("Új-Zéland", "NZ");
            AddCountryIfNotExists("Ukrajna", "UA");
            AddCountryIfNotExists("Uruguay", "UY");
            AddCountryIfNotExists("Üzbegisztán", "UZ");
            AddCountryIfNotExists("Vanuatu", "VU");
            AddCountryIfNotExists("Venezuela", "VE");
            AddCountryIfNotExists("Vietnam", "VN");
            AddCountryIfNotExists("Wallis és Futuna ", "WF");
            AddCountryIfNotExists("Zambia", "ZM");
            AddCountryIfNotExists("Zimbabwe", "ZW");
            AddCountryIfNotExists("Zöld-foki-szigetek", "CV");
        }

        private void AddCountryIfNotExists(string name, string cityCode)
        {
            if (_context.Countries.IgnoreQueryFilters().Any(c => c.Name == name && c.CityCode == cityCode))
            {
                return;
            }

            _context.Countries.Add(new Country() { Name = name, CityCode = cityCode });
            _context.SaveChanges();
        }
    }
}
