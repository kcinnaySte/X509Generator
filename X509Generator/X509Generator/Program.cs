using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace X509Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Cert name: ");
            var subject = Console.ReadLine();

            Console.Write("Enter Organisation name: ");
            var organisation = Console.ReadLine();

            Console.Write("Enter Valid Time in Years: ");
            var validTime = Convert.ToInt32( Console.ReadLine());

            Console.Write("Enter Country name: ");
            var country = Console.ReadLine();

            var cert = Certificates.GenerateCertificate( subject, organisation, validTime, country);

            using (BinaryWriter bw = new BinaryWriter(new StreamWriter($"{subject}.pfx").BaseStream))
            {
                bw.Write(cert.Export(X509ContentType.Pfx));
            }

            using (BinaryWriter bw = new BinaryWriter(new StreamWriter($"{subject}.cer").BaseStream))
            {
                bw.Write(cert.Export(X509ContentType.Cert));
            }
            
        }

    }
}
