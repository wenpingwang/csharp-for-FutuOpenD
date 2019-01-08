using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    interface IExecutor
    {
        int getnProtoID();

        ProtoBufPackage buildPackage();

        void execute(ProtoBufPackage pack);

        object getValue();
    }
}
