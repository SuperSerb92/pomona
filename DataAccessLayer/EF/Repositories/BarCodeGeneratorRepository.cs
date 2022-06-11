using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
//using RJCP.IO.Ports;


namespace DataAccessLayer.EF.Repositories
{
    public class BarCodeGeneratorRepository : IBarCodeGeneratorRepository
    {
         bool _continue;
         SerialPort _serialPort;
        private readonly DbModelContext _context;
        public BarCodeGeneratorRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(BarCodeGenerator barCode)
        {
           _context.Add(barCode);
        }

        public void Delete(BarCodeGenerator barCode)
        {
            _context.Remove(barCode);
        }

        public IEnumerable<BarCodeGenerator> GetBarCodeGenerators()
        {
            return _context.BarCodeGenerators.ToList();
        }
        int VrednostSaVage = 0;
        bool initOpenPort = false;

        public void SaveChanges()
        {
           _context.SaveChanges();
        }

        public void Update(BarCodeGenerator barCode)
        {
            _context.Update(barCode);
          
        }
        //public  void Read()
        //{
        //    while (_continue)
        //    {
        //        try
        //        {
        //            string message = _serialPort.ReadLine();
        //            Console.WriteLine(message);
        //        }
        //        catch (TimeoutException) { }
        //    }
        //}
        public void Measure(ref decimal vrednostSaVage,string port)
        {
            try
            {

               // Thread readThread = new Thread(Read);

                // Create a new SerialPort object with default settings.
                _serialPort = new SerialPort();

                // Allow the user to set the appropriate properties.
                _serialPort.PortName = port;
                _serialPort.BaudRate = 9600;
                _serialPort.Parity = Parity.None;
                _serialPort.DataBits = 8;
                _serialPort.StopBits = StopBits.One;
                _serialPort.Handshake = Handshake.None;
                _serialPort.ReceivedBytesThreshold = 9;
                _serialPort.WriteTimeout = 2000;
                _serialPort.ReadTimeout = 2000;


                while (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }
                _continue = true;
                //     readThread.Start();

                _serialPort.WriteLine("P");
                string vrednost = _serialPort.ReadLine();
                string[] indataArray = vrednost.Split(' ');

                indataArray = indataArray.Where(x => !string.IsNullOrEmpty(x) && x != "\r\n" && x != "n" &&
                x != "\n" && x != "\r" && x != "r" && x != "enter." && x != "+" && x != "ACCEPT" && x != "OVER" && x != "+enter").ToArray();

                if (indataArray.Length >= 2)
                {
                    if (indataArray.Length > 4)
                    {
                        _serialPort.Close();
                        _continue = false;
                        return;
                    }
                    // 2. ako ima ? znaci da vaga nije bila mirna
                    if (Array.Exists(indataArray, E => E == "?") == true)
                    {
                        _serialPort.Close();
                        _continue = false;
                        return;
                    }
                    //3. ako nije prvi u nizu masa
                    decimal vr = 0;
                    if (!decimal.TryParse(indataArray[0], out vr))
                    {
                        _serialPort.Close();
                        _continue = false;
                        return;
                    }
                    //4. ako nije kg onda su grami - vrati u grame
                    if (indataArray[1].ToUpper() != "KG")
                    {
                        vrednostSaVage = (Convert.ToDecimal(indataArray[0]))/1000;
                        _continue = false;
                        
                    }
                    else
                    {
                        vrednostSaVage = (Convert.ToDecimal(indataArray[0])) * 1000;
                        _continue = false;
                    }
                }

            }
            catch (Exception ex)
            {
                _serialPort.Close();
               // throw ex;
            }
            finally
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
            }

        }

    }
}
