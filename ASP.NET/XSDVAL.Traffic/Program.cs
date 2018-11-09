using System;
using System.Collections.Generic;
using System.IO;
using XSDVAL.Traffic.XSD;
namespace XSDVAL.Traffic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("開始產生Xml檔案");
            CreateXML();
            Console.WriteLine("產生Xml檔案結束");
            Console.ReadKey();
        }

        static void CreateXML()
        {
            List<DetectionLinkType> DetectionLink = new List<DetectionLinkType>
            {
                new DetectionLinkType()
                {
                    LinkID = "600817200030A",
                    Bearing = BearingEnum.E,
                    RoadDirection = RoadDirectionEnum.E,
                    LaneNum = 2,
                    ActualLaneNum = 2
                }
            };

            List<VDType> VDs = new List<VDType>
            {
                new VDType()
                {
                    VDID = "0120C0",
                    BiDirectional = BiDirectionalEnum.Item0,
                    DetectionLinks = DetectionLink.ToArray(),
                    LocationType = LocationTypeEnum.Item3,
                    DetectionType = DetectionTypeEnum.Item3,
                    PositionLon = 121.51164,
                    PositionLat = 25.04985,
                    RoadID = "00817",
                    RoadName = "鄭州路",
                    RoadClass = RoadClassEnum.Item3,
                }
            };

            VDListType VDList = new VDListType()
            {
                UpdateTime = DateTime.Now,
                UpdateInterval = 86400,
                AuthorityCode = AuthorityCodeEnum.TPE,
                VDs = VDs.ToArray(),
            };
            var Path = System.IO.Path.Combine(Directory.GetParent("..").FullName , @"XSD\VD.xml");
            Utility.Helper.XMLHelper.Serialize(VDList, Path);
        }
    }
}
