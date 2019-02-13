

// basic file operations
#include <iostream>
#include <fstream>
#include <stdlib.h>  
 
using namespace std;

int main()
{
   int number; 
  ofstream myfile;
  myfile.open ("Q1Input.txt");
  
  for (int i=0;i<16;i++)
  {
  number = rand() % 10 +1 ;
  if (number %2==0){
  number=1;	
  }
  else{
  number =0;
  }
  
  myfile<<"Z"<<i+1<<","<<number<<"\n";
  }
  //myfile << "Writing this to a file.\n";
  myfile.close();
  return 0;
}


