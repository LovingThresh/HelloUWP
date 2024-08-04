using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace DependencyObjectClassHierarchy
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Type rootType = typeof(DependencyObject);
        TypeInfo rootTypeInfo = typeof(DependencyObject).GetTypeInfo();
        List<Type> classes = new List<Type>();
        private Brush highlightBrush = new SolidColorBrush(new UISettings().UIElementColor(UIElementType.Highlight));

        public MainPage()
        {
            this.InitializeComponent();

            AddToClassList(typeof(Windows.UI.Xaml.DependencyObject));

            classes.Sort((t1, t2) => string.CompareOrdinal(t1.GetTypeInfo().Name, t2.GetTypeInfo().Name));

            ClassAndSubclasses rootClass = new ClassAndSubclasses(rootType);
            AddToTree(rootClass, classes);

            Display(rootClass, 0);
        }

        private void Display(ClassAndSubclasses parentClass, int indent)
        {
            TypeInfo typeInfo = parentClass.Type.GetTypeInfo();
            TextBlock txtblk = new TextBlock();
            txtblk.Inlines.Add(new Run { Text = new string(' ', 8 * indent) });
            txtblk.Inlines.Add(new Run {Text = typeInfo.Name});

            if (typeInfo.IsSealed)
                txtblk.Inlines.Add(new Run { Text = " (sealed)", Foreground = highlightBrush });

            IEnumerable<ConstructorInfo> constructorInfos = typeInfo.DeclaredConstructors;
            int publicConstructorCount = 0;

            foreach (var constructorInfo in constructorInfos)
            {
                if (constructorInfo.IsPublic)
                    publicConstructorCount += 1;
            }

            if (publicConstructorCount == 0)
                txtblk.Inlines.Add(new Run { Text = " (no-instantiable)", Foreground = highlightBrush });

            StackPanel.Children.Add(txtblk);

            foreach (var subclass in parentClass.Subclasses)
            {
                Display(subclass, indent + 1);
            }
        }

        private void AddToTree(ClassAndSubclasses parentClass, List<Type> classes)
        {
            foreach (var type in classes)
            {
                Type baseType = type.GetTypeInfo().BaseType;

                if (baseType == parentClass.Type)
                {
                    ClassAndSubclasses childClass = new ClassAndSubclasses(type);
                    parentClass.Subclasses.Add(childClass);
                    AddToTree(childClass, classes);
                }
            }
        }

        private void AddToClassList(Type sampleType)
        {
            Assembly assembly = sampleType.GetTypeInfo().Assembly;

            foreach (var type in assembly.ExportedTypes)
            {
                TypeInfo typeInfo = type.GetTypeInfo();

                if (typeInfo.IsPublic && rootTypeInfo.IsAssignableFrom(typeInfo))
                {
                    classes.Add(type);
                }
            }
        }
    }
}