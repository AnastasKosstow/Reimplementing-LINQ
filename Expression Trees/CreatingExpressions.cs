
namespace Expression_Trees
{
    using System;
    using System.Reflection;
    using System.Linq.Expressions;

    public static class CreatingExpressions
    {
        public static void CreateExpressions()
        {
            // Create class instance
            var instance = New<TestClass>.Instance;
            Console.WriteLine(instance.Invoke().SomeMethod());


            /* Create an Expression that call a method */
            /* x => x.SomeMethod() */

            // Parameter Expression
            var parameterExpression = Expression.Parameter(typeof(TestClass), "x");

            // Method Expression
            var methodCallExpression =
                Expression.Call(
                    parameterExpression, 
                    typeof(TestClass).GetTypeInfo().GetMethod(nameof(TestClass.SomeMethod)));

            // Lambda Expression
            var lambdaExpression =
                Expression.Lambda<Func<TestClass, string>>
                (methodCallExpression, parameterExpression);

            // Result
            Console.WriteLine(lambdaExpression.Compile().Invoke(new TestClass()));



            /* Create an Expression that call a method with parameters */
            /* x => x.SomeMethod(Telerik, new AnotherClass { StringValue = "Academy" }) */

            // Parameter Expression
            // x
            parameterExpression = Expression.Parameter(typeof(TestClass));

            // Constant Expression
            // Telerik
            var constantExpression = Expression.Constant("Telerik");

            // New Expression
            // new AnotherClass()
            var newExpression = Expression.New(typeof(AnotherClass));

            // Right Constant Expression
            // Academy
            var secondConstantExpression = Expression.Constant("Academy");

            // Member Binding
            // { StringValue = "Academy" } -> (AnotherClass)
            var memberBinding = Expression.Bind(typeof(AnotherClass).GetTypeInfo().GetProperty(nameof(AnotherClass.StringValue)),
                secondConstantExpression);

            // Init Expression
            // new AnotherClass() { StringValue = "Academy" }
            var initExpression = Expression.MemberInit(newExpression, memberBinding);

            // x => x.SomeMethod(Telerik, new AnotherClass { StringValue = "Academy" })
            methodCallExpression = Expression.Call(
                parameterExpression,
                    typeof(TestClass).GetTypeInfo().GetMethod(nameof(TestClass.OtherMethod)),
                    constantExpression, initExpression);

            var lambda = Expression.Lambda<Func<TestClass, string>>
                (methodCallExpression, parameterExpression);


            // Result
            Console.WriteLine(lambda.Compile().Invoke(new TestClass()));
        }
    }

    public static class New<T>
    {
        public static Func<T> Instance =
            Expression.Lambda<Func<T>>(Expression.New(typeof(T)))
            .Compile();
    }
}

