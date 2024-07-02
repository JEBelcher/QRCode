// See https://aka.ms/new-console-template for more information
using System;
using QRCoder;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string ssid;
        string password;
        // Input your Wi-Fi SSID
        Console.Write("Enter SSID ");
        ssid = Console.ReadLine();
        // Input your Wi-Fi Password
        Console.Write("\nEnter Password ");
        password = Console.ReadLine();
        string encryption = "WPA"; // Options: WEP, WPA 
        if (ssid == "" || password == "")
        {
            Console.WriteLine("SSID and Password must contain a value.  Press any key to exit");
            Console.Read();
            Environment.Exit(1); // Exit with error code 1
            
        }

        // Generate the Wi-Fi QR code content
        string wifiQRCodeContent = $"WIFI:T:{encryption};S:{ssid};P:{password};;";

        // Generate the QR code
        GenerateQRCode(wifiQRCodeContent);

        Console.WriteLine("QR Code generated successfully!");
        Console.WriteLine("Press any key to exit");
        Console.Read();
    }

    static void GenerateQRCode(string content)
    {
        using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        {
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q))
            {
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    {
                        // Save the QR code image as a PNG file
                        qrCodeImage.Save("wifi_qrcode.png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
        }
    }
}

   