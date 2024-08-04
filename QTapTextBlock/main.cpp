#include "QTapTextBlock.h"
#include <QtWidgets/QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    QTapTextBlock w;
    w.show();
    return a.exec();
}
