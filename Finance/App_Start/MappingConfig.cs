using Dapper.FluentMap;
using Finance.Models.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            FluentMapper.Initialize(cfg =>
            {
                cfg.AddMap(new JournalMap());
            });

        }
    }
}