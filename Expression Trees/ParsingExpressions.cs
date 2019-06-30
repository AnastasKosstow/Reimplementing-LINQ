
namespace Expression_Trees
{
    using System;
    using System.Linq.Expressions;

    public class TestClass
    {
        public string SomeMethod()
        {
            return "Telerik Academy!";
        }
    }

    public class ExpClass
    {
        public void PrintExpression<T>(Expression<Action<T>> action)
        {
            var body = action.Body;
            ParseExpression(body);
        }

        public void PrintExpression<T>(Expression<Func<T>> func)
        {
            var body = func.Body;
            ParseExpression(body);
        }

        public void ParseExpression(Expression exp)
        {
            if (exp is UnaryExpression)
            {
                var converExp = (UnaryExpression)exp;
                var operand = converExp.Operand;
                ParseExpression(operand);
            }

            else if (exp is ConstantExpression)
            {
                var expressionType = (ConstantExpression)exp;
                Console.WriteLine(expressionType.Value);
            }

            else if (exp is MethodCallExpression)
            {
                var expressionType = (MethodCallExpression)exp;
                var type = (expressionType.Object)?.Type.Name ?? "Static class";
                var methodName = expressionType.Method.Name;

                ParameterExpression @params = (ParameterExpression)expressionType.Object;
                var parameters = new ParameterExpression[] { @params };
                var lambda = Expression.Lambda(expressionType, parameters);

                Console.WriteLine(
                    methodName + "\n" + type
                    + "\n" + lambda.Compile().DynamicInvoke(new TestClass()));
            }

            else if (exp.NodeType == ExpressionType.Lambda)
            {
                var lambda = (LambdaExpression)exp;
                foreach (var parameter in lambda.Parameters)
                    Console.Write($"Type: {parameter.Type} -- Parameter name: {parameter.Name}\n");
            }

            else if (exp.NodeType == ExpressionType.MemberAccess)
            {
                var memberExp = (MemberExpression)exp;
                var value = GetMemberAccessValue(memberExp);
                Console.WriteLine(value);
            }

            else if (exp.NodeType == ExpressionType.Add)
            {
                var binaryExp = (BinaryExpression)exp;
                var left = GetMemberAccessValue((MemberExpression)binaryExp.Left);
                var right = GetMemberAccessValue((MemberExpression)binaryExp.Right);
                Console.WriteLine((int)left + (int)right);
            }
        }

        private object GetMemberAccessValue(MemberExpression ex)
        {
            var memberExp = (MemberExpression)ex;
            var constExp = (ConstantExpression)memberExp.Expression;
            var compiledLambdaScopeField = constExp.Value.GetType().GetField(memberExp.Member.Name);
            return compiledLambdaScopeField.GetValue(constExp.Value);
        }
    }

    public static class ParsingExpressions
    {
        public static void ParseExpressions()
        {
            ExpClass ex = new ExpClass();

            // Method call
            ex.PrintExpression<TestClass>(x => x.SomeMethod());

            // Constant
            ex.PrintExpression(() => 1);

            // Casting
            Expression<Func<object>> objectFunc = () => 1;
            ex.PrintExpression(objectFunc);

            // Lambda
            Expression<Func<int, int, int>> lmbdFunc = (x, y) => x + y;
            ex.ParseExpression(lmbdFunc);

            // Member access
            int id = 100;
            ex.PrintExpression(() => id);

            // Binary ex
            int first = 20;
            int second = 30;
            ex.PrintExpression(() => first + second);
        }
    }
}
