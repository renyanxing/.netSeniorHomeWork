using ExpressionDemo.Visitor;
using Microsoft.VisualStudio.TestPlatform;
using System;
using System.Linq.Expressions;

namespace LinqToSql
{
    public class LinqToSqlServer
    {
        static void Main(string[] args)
        {
            Where<string>(x => x == "");
        }
        static public string Where<T>(Expression<Func<T, bool>> lambda)
        {

            ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
            vistor.Visit(lambda);
            return vistor.Condition();
        }

    }
}
