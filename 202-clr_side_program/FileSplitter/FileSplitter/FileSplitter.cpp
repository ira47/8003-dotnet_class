#include <iostream>
#include <cstring>
#include <fstream>
#include <vector>

static int ziPerLine = 10;
static int charPerLine = 5 * ziPerLine + 1;
static int maxLine = 1000000;
static int maxParagraphLength = 10000;
static char** content = NULL;
static int oldMaxLine;
static int totalLine;
// static char fileName[] = "C:\\Users\\beibe\\Desktop\\dotnet相关文件\\各种书\\bookbao.cc李凉武侠全集\\李凉 暗器高手.txt";
static char fileName[] = "C:\\Users\\beibe\\Desktop\\dotnet相关文件\\各种书\\格局-吴军著.txt";
static char outFileName[] = "C:\\Users\\beibe\\Desktop\\李凉 暗器高手111.txt";
// static std::string fileType = "gb2312";
static std::string fileType = "utf8";

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
        if (fileType == "gb2312") {
            if ((zi & 0xF0) != 0x00) {
                ziWidth = 2;
                charLength = 2;
            }
            else {
                ziWidth = 1;
                charLength = 1;
            }
        }
        else {
            ziWidth = 2;
            if ((zi & 0xF8) == 0xF8)
                charLength = 5;
            else if ((zi & 0xF0) == 0xF0)
                charLength = 4;
            else if ((zi & 0xE0) == 0xE0)
                charLength = 3;
            else if ((zi & 0xC0) == 0xC0)
                charLength = 2;
            else {
                charLength = 1;
                ziWidth = 1;
            }
        }

        if (ziTotalWidth + ziWidth <= ziPerLine) {
            charTotalLength += charLength;
            indexChar += charLength;
            ziTotalWidth += ziWidth;
        }
        else {
            char* line = new char[charPerLine];
            // std::cout << charTotalLength << std::endl;
            // std::cout << paragraph << ' ' << startPos << ' ' << charTotalLength << std::endl;
            strncpy_s(line, charPerLine, paragraph + startPos, charTotalLength);
            // std::cout << ziTotalWidth << ' ' << charTotalLength << std::endl;
            lines.push_back(line);
            // lines.push_back(ziTotalWidth);
            startPos += charTotalLength;
            charTotalLength = charLength;
            ziTotalWidth = ziWidth;
        }
    }
    if (charTotalLength) {
        char* line = new char[charPerLine];
        strncpy_s(line, charPerLine, paragraph + startPos, charTotalLength);
        // std::cout << ziTotalWidth << ' ' << charTotalLength << std::endl;
        lines.push_back(line);
    }
    return lines;
}

int main()
{
    if (content != NULL) {
        for (int i = 0; i < oldMaxLine; i++)
            delete[] content[i];
        delete[] content;
    }
    std::ifstream bookFile(fileName);
    std::ofstream bookOutFile(outFileName);
    // std::cout << fileName;
    // if (!bookFile)
        // return content = NULL;
        // return NULL;
    char* paragraph = new char[maxParagraphLength];
    // string paragraph;
    int originalLine = 0;
    int dividedLine = 0;
    while (bookFile.getline(paragraph, maxParagraphLength)) {
        // int paragraphLength = strlen(paragraph);
        // paragraph[paragraphLength - 1] = '\0';
        // paragraph[paragraphLength - 2] = '\0';
        // std::vector<int> lines = getLines(paragraph);
        std::vector<char*> lines = getLines(paragraph);
        dividedLine += lines.size();
        // for (int line : lines)
        for (char* line : lines)
            bookOutFile << line << '\n';
        originalLine++;
    }
    std::cout << dividedLine << std::endl << originalLine;
    bookFile.close();
    bookOutFile.close();
}

/*
int main()
{
    const string fileName = "C:\\Users\\beibe\\Desktop\\bookbao.cc李凉武侠全集\\李凉 暗器高手.txt";
    const int charPerLine = 35;
    ifstream nameFile;
    string input;
    nameFile.open(fileName, ios::in);
    if (!nameFile)
    {
        cout << "File open error!" << endl;
        return 0;
    }
    int originalLine = 0;
    int dividedLine = 0;
    char* line = new char[100];
    while (nameFile.getline(line,10000))
    {
        int charLength = strlen(line);
        int lineLength = (charLength - 1) / charPerLine + 1;
        for (int i = 0; i < lineLength; i++)
        {
            substr
            dividedLine++;
        }
        getline(nameFile, input);
        originalLine++;
    }
    nameFile.close();
    cout << originalLine << endl << dividedLine << endl;
    return 0;
}*/
/* int main()
{
    fstream nameFile;
    const string fileName = "C:\\Users\\beibe\\Desktop\\bookbao.cc李凉武侠全集\\李凉 暗器高手.txt";
    while (string line = cin.getline(fileName, 35)) {
        cout << line;
    }
}*/
