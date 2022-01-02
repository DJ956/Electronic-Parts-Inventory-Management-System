using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Infra
{
    public class DBInitializer
    {
        public static void Initialize(EPIMSContext context)
        {
            context.Database.EnsureCreated();

            InitCategory(context);
            InitProduct(context);
            InitProductImage(context);
            InitProductDetail(context);

            context.SaveChanges();

        }

        private static void InitCategory(EPIMSContext context)
        {
            if (context.CategoryDatas.Any()) { return; }

            //カテゴリ
            var categoryes = new CategoryData[]
            {
                new CategoryData{CategoryName="ディスプレイ・表示系"},
                new CategoryData{CategoryName="基板・ブレッドボード"},
                new CategoryData{CategoryName="カメラ"},
                //一般
                new CategoryData{CategoryName="電池一般"},
                new CategoryData{CategoryName="抵抗"},
                new CategoryData{CategoryName="コンデンサ"},
                new CategoryData{CategoryName="可変抵抗"},
                new CategoryData{CategoryName="スイッチ"},
                new CategoryData{CategoryName="発振子"},
                new CategoryData{CategoryName="ピンヘッダ・フレーム"},
                new CategoryData{CategoryName="PC関連フレーム"},
                new CategoryData{CategoryName="AV機器コネクタ"},
                new CategoryData{CategoryName="電源用コネクタ"},
                new CategoryData{CategoryName="汎用コネクタ・端子"},
                new CategoryData{CategoryName="RFコネクタ"},
                new CategoryData{CategoryName="ICソケット関連"},
                new CategoryData{CategoryName="フォトデバイス"},
                new CategoryData{CategoryName="音響部品"},
                new CategoryData{CategoryName="リレー部品"},
                new CategoryData{CategoryName="動力部品"},
                new CategoryData{CategoryName="電池ケース"},
                new CategoryData{CategoryName="チップ部品"},
                new CategoryData{CategoryName="コイル・インダクタ"},
                new CategoryData{CategoryName="フィルター一般"},
                new CategoryData{CategoryName="熱関連"},
                new CategoryData{CategoryName="配線材料"},
                new CategoryData{CategoryName="LED"},
                //工具
                new CategoryData{CategoryName="工作用品"},
                new CategoryData{CategoryName="ケース"},
                new CategoryData{CategoryName="ナット・ねじ"},
                //センサー一般
                new CategoryData{CategoryName="ジャイロセンサー"},
                new CategoryData{CategoryName="GPS"},
                new CategoryData{CategoryName="加速度センサー"},
                new CategoryData{CategoryName="湿度センサー"},
                new CategoryData{CategoryName="温度センサー"},
                new CategoryData{CategoryName="光センサー"},
                new CategoryData{CategoryName="音センサー"},
                new CategoryData{CategoryName="超音波センサー"},
                new CategoryData{CategoryName="pHセンサー"},
                new CategoryData{CategoryName="磁気センサー"},
                new CategoryData{CategoryName="圧力センサー"},
                //マイコン関連
                new CategoryData{CategoryName="PIC"},
                new CategoryData{CategoryName="Arduino"},
                new CategoryData{CategoryName="RaspberryPi"},
                //電源
                new CategoryData{CategoryName="スイッチングACアダプター"},
                new CategoryData{CategoryName="DC"},
            };
            context.CategoryDatas.AddRange(categoryes);
        }


        private static void InitProduct(EPIMSContext context)
        {

            if (context.ProductDatas.Any()) { return; }

            //製品
            var ProductDatas = new ProductData[]
            {
                new ProductData{ProductName="PIC16F1827", ModelName="PIC16F1827", Maker="Microchip", CategoryNo=17 },
                new ProductData{ProductName="PIC16F1938", ModelName="PIC16F1938", Maker="Microchip", CategoryNo=17 },
            };

            context.ProductDatas.AddRange(ProductDatas);
        }

        private static void InitProductImage(EPIMSContext context)
        {
            if (context.ProductImageDatas.Any()) { return; }

            var Images = new ProductImageData[]
            {
                new ProductImageData(){ProductNo=1, ImagePath=@"C:\Users\dexte\Documents\GitHub\Electronic-Parts-Inventory-Management-System\SampleImage\pic16f1827_1.jpg"},
                new ProductImageData(){ProductNo=1, ImagePath=@"C:\Users\dexte\Documents\GitHub\Electronic-Parts-Inventory-Management-System\SampleImage\pic16f1827_2.jpg"},
                new ProductImageData(){ProductNo=2, ImagePath=@"C:\Users\dexte\Documents\GitHub\Electronic-Parts-Inventory-Management-System\SampleImage\pic16f1938_1.jpg"},
                new ProductImageData(){ProductNo=2, ImagePath=@"C:\Users\dexte\Documents\GitHub\Electronic-Parts-Inventory-Management-System\SampleImage\pic16f1938_2.jpg"}
            };

            context.ProductImageDatas.AddRange(Images);
        }

        private static void InitProductDetail(EPIMSContext context)
        {
            if (context.ProductDetailDatas.Any()) { return; }

            var Details = new ProductDetailData[]
            {
                new ProductDetailData(){ProductNo = 1, CountName="個", Price=190,Url="https://akizukidenshi.com/catalog/g/gI-04430/",
                    DataSheetPath=@"C:\Users\dexte\Documents\GitHub\Electronic-Parts-Inventory-Management-System\SampleDataSheet\pic16f1827.pdf",
                    SpecDesc=@"・シリーズ：PIC16F
・電源電圧：1.8～5.5V
・コアサイズ：8bit
・命令長：14bit
・クロック：32MHz
・プログラムメモリ：4kW
・EEPROM：256B
・RAM：384B
・GPIO：16pin
・ADC：12Ch
・UART/USART：1Ch
・I2C：2Ch
・SPI：2Ch
・タイマ：5Ch
・オシレータ：内蔵/外付
・パッケージ：DIP18", },
                new ProductDetailData(){ProductNo = 2, CountName="個", Price=220,Url="https://akizukidenshi.com/catalog/g/gI-04357/",
                    DataSheetPath=@"C:\Users\dexte\Documents\GitHub\Electronic-Parts-Inventory-Management-System\SampleDataSheet\pic16f193X.pdf",
                    SpecDesc=@"・シリーズ：PIC16F
・電源電圧：1.8～5.5V
・コアサイズ：8bit
・命令長：14bit
・クロック：32MHz
・プログラムメモリ：16kW
・EEPROM：256B
・RAM：1kB
・GPIO：25pin
・ADC：11Ch
・UART/USART：1Ch
・I2C：1Ch
・SPI：1Ch
・タイマ：5Ch
・オシレータ：内蔵/外付
・パッケージ：DIP28", },

            };

            context.ProductDetailDatas.AddRange(Details);
        }

    }
}
