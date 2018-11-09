using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSDVAL.PTX
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("開始產生Xml檔案");
            CreateXML();
            Console.Write("產生Xml檔案結束");
            Console.ReadKey();
        }

        static void CreateXML()
        {
            List<BusRouteTypeOperator> Operator = new List<BusRouteTypeOperator>
            {
                new BusRouteTypeOperator()
                {
                    OperatorID = "1100",
                    OperatorCode ="DananBus",
                }
            };

            List<BusRouteType> Routes = new List<BusRouteType>
            {
                new BusRouteType()
                {
                    RouteID = "17686",
                    RouteName = new NameType {
                        Zh_tw="216",
                        En="216",
                    },
                    HasSubRoutes=true,
                    Operators = Operator.ToArray(),
                    RouteType = BusRouteTypeEnum.Item11,
                    ServiceType= new  BusRouteTypeServiceType{
                        IsFreeBus=false,
                        IsTaiwanTripBus=false,
                        IsTourBus=true,
                        IsTouristBus=false,
                        IsBRTBus=false,
                        IsMedicalBus=false,
                        IsNightBus=true,
                        IsTrunkBus=true,
                        IsTHSRShuttleBus=false,
                        IsTRAShuttleBus=false,
                        IsAirportShuttleBus=false,
                        IsActivityShuttleBus=true,
                    },
                    TicketPriceDescription = new NameType {
                         Zh_tw="一段票",
                         En="1 segment",
                    },
                    DepartureStopName =new NameType {
                         Zh_tw="新北投",
                         En="Xinbeitou"
                    },
                    DestinationStopName=new NameType {
                        Zh_tw="捷運劍潭站",
                        En="MRT Jiantan Sta."
                    },
                    StartStop= new BusRouteTypeStartStop {
                        StopID="186328",
                        StopName=new NameType {
                            Zh_tw="新北投",
                            En="Xinbeitou"
                        },
                    },
                    EndStop= new BusRouteTypeEndStop {
                        StopID="186288",
                        StopName=new NameType {
                            Zh_tw="捷運劍潭站",
                            En="MRT Jiantan Sta."
                        },
                    },
                    IsCircular=true,
                }
            };
            BusRouteListType VDList = new BusRouteListType()
            {
                UpdateTime = DateTime.Now,
                UpdateInterval = 86400,
                AuthorityCode = "TPE",
                Routes = Routes.ToArray(),
            };
            var Path = System.IO.Path.Combine(Directory.GetParent("..").FullName, @"XSD\Route.xml");
            Utility.Helper.XMLHelper.Serialize(VDList, Path);
        }
    }
}
