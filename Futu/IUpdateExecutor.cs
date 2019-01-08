using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    interface IUpdateExecutor : IExecutor
    {
        /**
	 * 解析推送数据
	 * @param pack
	 * @return
	 * @throws InvalidProtocolBufferException
	 */
        object parse(ProtoBufPackage pack);

        /**
         * 推送数据不确定，此方法的作用是过滤,寻找匹配的数据后再由用户处理业务
         * @param t
         */
        void handler(object res);

        /**
         * 推送数据协议ID
         * 因为推送数据没有显示的api调用。只能对应api提供回调功能处理数据
         *  如:
         *  3004获取股票基本行情 的推送协议为  3005推送股票基本报价  
         *  33008获取分时 的推送协议为 009推送分时
         * @return
         */
        int getnUpdateProtoID();
        
    }
}
