using System;

namespace CSType
{
    public class CSType
    {
        public static void Main(string[] args)
        {
            CSType csType = new CSType();
            csType.Types();
        }

        public void Types()
        {
            Type nonGenericInterfaceType = typeof(INonGenericInterface);
            Console.WriteLine(string.Format("Type of non generic interface: {0}", nonGenericInterfaceType));

            NonGenericInterfaceClass nonGenericInterfaceClass = new NonGenericInterfaceClass();
            Type nonGenericInterfaceClassType = nonGenericInterfaceClass.GetType();

            // Interface を実装したクラスは当然 is で判定可能
            Console.WriteLine(string.Format("{0} is {1}? {2}", nonGenericInterfaceClass, nonGenericInterfaceType, nonGenericInterfaceClass is INonGenericInterface));

            // Interface を実装したクラスの Type からインターフェースを取り出してみる
            foreach (Type interfaceType in nonGenericInterfaceClassType.GetInterfaces())
            {
                Console.WriteLine(string.Format("Interface type of {0}: {1}", nonGenericInterfaceClassType, interfaceType));
            }

            SubClassOfNonGenericInterfaceClass subClassOfNonGenericInterfaceClass = new SubClassOfNonGenericInterfaceClass();
            Type subClassOfNonGenericInterfaceClassType = subClassOfNonGenericInterfaceClass.GetType();

            // 例えそのクラス自体がインターフェースを定義していなくても
            // インターフェースを実装したクラスのサブクラスであればインターフェースを取得できる事が分かる
            foreach (Type interfaceType in subClassOfNonGenericInterfaceClassType.GetInterfaces())
            {
                Console.WriteLine(string.Format("Interface type of {0}: {1}", subClassOfNonGenericInterfaceClassType, interfaceType));
            }

            // そもそもこういう書き方できるんだね、っていうw
            // しかし、genericInterfaceClass is IGenericInterface<> とは書けない
            Type genericInterfaceType = typeof(IGenericInterface<>);
            Console.WriteLine(string.Format("Type of generic interface: {0}", genericInterfaceType));

            GenericInterfaceClass genericInterfaceClass = new GenericInterfaceClass();
            Type genericInterfaceClassType = genericInterfaceClass.GetType();

            // Interface を実装したクラスの Type からインターフェースを取り出してみる
            foreach (Type interfaceType in genericInterfaceClassType.GetInterfaces())
            {
                Console.WriteLine(string.Format("Interface type of {0}: {1}", genericInterfaceClassType, interfaceType));
                Console.WriteLine(string.Format("{0} is {1} ? {2}", genericInterfaceType, interfaceType, genericInterfaceType == interfaceType));
                Console.WriteLine(string.Format("{0} is {1} ? {2}", genericInterfaceType.GetGenericTypeDefinition(), interfaceType.GetGenericTypeDefinition(), genericInterfaceType.GetGenericTypeDefinition() == interfaceType.GetGenericTypeDefinition()));
            }
        }
    }
}
