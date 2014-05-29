﻿using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;
using System.Text;

namespace Bridge.NET
{
    public static class Helpers 
    {
        public static string GetOperatorMethodName(BinaryOperatorType op)
        {
            string name = "";

            switch (op)
            {
                case BinaryOperatorType.Add:
                    name = "Addition";
                    break;
                case BinaryOperatorType.BitwiseAnd:
                    name = "BitwiseAnd";
                    break;
                case BinaryOperatorType.BitwiseOr:
                    name = "BitwiseOr";
                    break;
                case BinaryOperatorType.ConditionalAnd:
                    name = "LogicalAnd";
                    break;
                case BinaryOperatorType.NullCoalescing:
                case BinaryOperatorType.ConditionalOr:
                    name = "LogicalOr";
                    break;
                case BinaryOperatorType.Divide:
                    name = "Division";
                    break;
                case BinaryOperatorType.Equality:
                    name = "Equality";
                    break;
                case BinaryOperatorType.ExclusiveOr:
                    name = "ExclusiveOr";
                    break;
                case BinaryOperatorType.GreaterThan:
                    name = "GreaterThan";
                    break;
                case BinaryOperatorType.GreaterThanOrEqual:
                    name = "GreaterThanOrEqual";
                    break;
                case BinaryOperatorType.InEquality:
                    name = "Inequality";
                    break;
                case BinaryOperatorType.LessThan:
                    name = "LessThan";
                    break;
                case BinaryOperatorType.LessThanOrEqual:
                    name = "LessThanOrEqual";
                    break;
                case BinaryOperatorType.Modulus:
                    name = "Modulus";
                    break;
                case BinaryOperatorType.Multiply:
                    name = "Multiply";
                    break;
                case BinaryOperatorType.ShiftLeft:
                    name = "LeftShift";
                    break;
                case BinaryOperatorType.ShiftRight:
                    name = "RightShift";
                    break;
                case BinaryOperatorType.Subtract:
                    name = "Subtraction";
                    break;
                default:
                    name = "";
                    break;
            }

            return "op_" + name;
        }
        
        
        public static void AcceptChildren(this AstNode node, IAstVisitor visitor)
        {
            foreach (AstNode child in node.Children)
            {
                child.AcceptVisitor(visitor);
            }
        }

        public static string GetScriptName(MethodDeclaration method, bool separator) 
        {            
            return Helpers.GetScriptName(method.Name, method.Parameters.Count, separator);
        }

        public static string GetScriptName(MemberReferenceExpression member, bool separator) 
        {
            return Helpers.GetScriptName(member.MemberName, member.TypeArguments.Count, separator);
        }

        public static string GetScriptName(MethodDefinition method, bool separator) 
        {
            return Helpers.GetScriptName(method.Name, method.GenericParameters.Count, separator);
        }

        public static string GetScriptName(TypeDeclaration type, bool separator) 
        {
            return Helpers.GetScriptName(type.Name, type.TypeParameters.Count, separator);
        }

        public static string GetScriptName(AstType type, bool separator) 
        {
            string result = null;
            SimpleType simpleType = type as SimpleType;

            if (simpleType != null) 
            {
                result = Helpers.GetScriptName(simpleType.Identifier, simpleType.TypeArguments.Count, separator);
            }
            else
            {
                PrimitiveType primType = type as PrimitiveType;

                if (primType != null)
                {
                    result = Helpers.GetScriptName(primType.KnownTypeCode.ToString(), 0, separator);
                }
                else
                {
                    result = Helpers.GetScriptName(type.ToString(), 0, separator);
                }
            }
            
            var composedType = type as ComposedType;

            if (composedType != null)
            {
                result = Helpers.GetScriptName(composedType.BaseType, separator) + "." + result;
            }
            
            return result;
        }

        public static string GetScriptFullName(TypeDefinition type) 
        {
            return Helpers.ReplaceSpecialChars(type.FullName);
        }

        public static string GetScriptFullName(TypeReference type) 
        {
            StringBuilder builder = new StringBuilder(type.Namespace);

            if (builder.Length > 0)
            {
                builder.Append('.');
            }
            
            builder.Append(Helpers.ReplaceSpecialChars(type.Name));
            
            return builder.ToString();
        }

        public static string GetTypeMapKey(TypeDefinition type) 
        {
            return Helpers.GetScriptFullName(type);
        }

        public static string GetTypeMapKey(TypeInfo info) 
        {
            return (!string.IsNullOrEmpty(info.Namespace) ? (info.Namespace + ".") : "") + (!string.IsNullOrEmpty(info.GenericName) ? info.GenericName : info.FullName);
        }

        public static string GetTypeMapKey(TypeReference type) 
        {
            return Helpers.GetScriptFullName(type);
        }

        public static string GetScriptName(string name, int paramCount, bool separator) 
        {
            return Helpers.GetPostfixedName(name, paramCount, separator ? "$" : null);
        }

        public static string ReplaceSpecialChars(string name) 
        {
            return name.Replace('`', '$').Replace('/', '.');
        }

        private static string GetPostfixedName(string name, int paramCount, string separator) 
        {
            if (paramCount < 1)
            {
                return name;
            }

            if (string.IsNullOrEmpty(separator))
            {
                return name;
            }
            
            return name + separator + paramCount;
        }

        public static bool IsSubclassOf(TypeDefinition thisTypeDefinition, TypeDefinition typeDefinition)
        {
            if (thisTypeDefinition.BaseType != null)
            {
                TypeDefinition baseTypeDefinition = null;

                try 
                { 
                    baseTypeDefinition = thisTypeDefinition.BaseType.Resolve(); 
                }
                catch { }

                if (baseTypeDefinition != null)
                {
                    return (baseTypeDefinition == typeDefinition || IsSubclassOf(baseTypeDefinition, typeDefinition));
                }
            }
            return false;
        }

        public static bool IsImplementationOf(TypeDefinition thisTypeDefinition, TypeDefinition interfaceTypeDefinition)
        {
            foreach (TypeReference interfaceReference in thisTypeDefinition.Interfaces)
            {
                if (interfaceReference == interfaceTypeDefinition)
                {
                    return true;
                }

                TypeDefinition interfaceDefinition = null;
                
                try 
                { 
                    interfaceDefinition = interfaceReference.Resolve(); 
                }
                catch { }

                if (interfaceDefinition != null && IsImplementationOf(interfaceDefinition, interfaceTypeDefinition))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsAssignableFrom(TypeDefinition thisTypeDefinition, TypeDefinition typeDefinition)
        {
            return (thisTypeDefinition == typeDefinition || (typeDefinition.IsClass && !typeDefinition.IsValueType && IsSubclassOf(typeDefinition, thisTypeDefinition))
                || (typeDefinition.IsInterface && IsImplementationOf(typeDefinition, thisTypeDefinition)));
        }
    }
}