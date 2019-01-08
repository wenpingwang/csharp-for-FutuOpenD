using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class FutuOpenD
    {
        public static Session openSession(String ip, int port)
        {
            Session session = new DefaultSession();
            try
            {
                session.openSession(ip, port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
            }
            return session;
        }

        public static Session openSession(String ip, int port, bool keepAlive)
        {
            Session session = new DefaultSession();
            try
            {
                session.openSession(ip, port, keepAlive);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
            }
            return session;
        }
    }
}
