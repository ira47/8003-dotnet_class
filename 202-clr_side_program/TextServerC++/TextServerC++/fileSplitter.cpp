#include "pch.h"
#include "fileSplitter.h"
#include <iostream>
#include <cstring>
#include <fstream>
#include <vector>

// refer to this:
// https://docs.microsoft.com/en-us/cpp/build/walkthrough-creating-and-using-a-dynamic-link-library-cpp?view=vs-2019


static int ziPerLine = 80;
static int charPerLine = 5 * ziPerLine + 1;
static int maxParagraphLength = 10000;
static int oldMaxLine;
static int totalLine;
static int dividedLine = 0;

int mySum(int a, int b) 
{
    return a + b;
}

std::vector<char*> getLines(char* paragraph)
{
    std::vector<char*>lines;
    int indexChar = 0;
    int ziTotalWidth = 0;
    int charLength = 0;
    int startPos = 0;
    int charTotalLength = 0;
    int ziWidth = 0;
    while (paragraph[indexChar]) {
        char zi = paragraph[indexChar];
        if ((zi & 0xF0) != 0x00) {
            ziWidth = 2;
            charLength = 2;
        } else {
            ziWidth = 1;
            charLength = 1;
        }

        if (ziTotalWidth + ziWidth <= ziPerLine) {
            charTotalLength += charLength;
            indexChar += charLength;
            ziTotalWidth += ziWidth;
        } else {
            char* line = new char[charPerLine];
            strncpy_s(line, charPerLine, paragraph + startPos, charTotalLength);
            lines.push_back(line);
            startPos += charTotalLength;
            charTotalLength = charLength;
            ziTotalWidth = ziWidth;
        }
    }
    if (charTotalLength) {
        char* line = new char[charPerLine];
        strncpy_s(line, charPerLine, paragraph + startPos, charTotalLength);
        lines.push_back(line);
    }
    return lines;
}


void divide(char* inFileName, char* outFileName, int _ziPerLine)
{
    ziPerLine = _ziPerLine;

    std::ifstream bookFile(inFileName);
    std::ofstream bookOutFile(outFileName);
    char* paragraph = new char[maxParagraphLength];
    dividedLine = 0;
    while (bookFile.getline(paragraph, maxParagraphLength)) {
        std::vector<char*> lines = getLines(paragraph);
        for (char* line : lines) {
            bookOutFile << line << '\n';
        }
    }
    bookFile.close();
    bookOutFile.close();
}

