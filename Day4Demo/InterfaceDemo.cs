using System;
namespace InterfaceDemoProj
{
    interface IAdd
    {
        in AddMe(int num1, int num2);
    }

    interface ISub
    {
        in SubMe(int num1, int num2);
    }

    interface IProd
    {
        in ProdMe(int num1, int num2);
    }

    interface IDiv
    {
        in DivMe(int num1, int num2);
    }

    interface IAddSub : IAdd, ISub
    {

    }

    interface IAddProdDiv : IAdd, IProd, IDiv{}

    interface IAll : IAdd, ISub, IProd, IDiv
    {
        
    }
}