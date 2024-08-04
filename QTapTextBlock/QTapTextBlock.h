#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_QTapTextBlock.h"

class QTapTextBlock : public QMainWindow
{
    Q_OBJECT

public:
    QTapTextBlock(QWidget *parent = nullptr);
    ~QTapTextBlock();

private:
    Ui::QTapTextBlockClass ui;
};
