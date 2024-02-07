package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        int size = 0;//8;//this was for the test to be easier and faster
        int size2 = 0;
        int count = 0;
        int counter = 0;

        //size2 = size2 - 2;
        Scanner in = new Scanner(System.in);

            System.out.println("Please enter the even number from 8 to 80: ");
            size = in.nextInt();
            if(((size%2) != 0) || (size < 8 || size > 80)){
                do{
                    size = 0;
                    System.out.println("The input number is not even please enter even number: ");
                    size = in.nextInt();
                }while((size % 2) == 0 && ((size >= 8 && size <= 80)));
            }
        size2 = size / 2;
        // upper part
        //==========================================
        for (int i = 1; i <= size2; i++) {
            // printing dots
            for (int j = size2; j > i; j--) {
                System.out.print(".");
            }
            // printing sides with / and \
            for (int k = 0; k < i * 2 - 1; k++) {
                if (k == 0 || k == 2 * i - 2) {
                    if (k == 2 * i - 2){
                        if (k==0) {
                            System.out.print("/");

                        }
                        System.out.print("\\");
                        for (int j = size2; j > i; j--) {
                            //int counter = 0;
                            //counter = i;
                            System.out.print(".");
                        }
                    }else{
                        System.out.print("/");
                    }
                }
                else {

                    count = count + 1;
                    //for (int j = size2; j > i; j++) {
                    // if (count > 1 && size2 == 4) {
                    //System.out.print(" ");
                    //System.out.print("/");
                    //}else{

                    //if (i>count){//
                    //if(size2 > count){
                       // System.out.print(" ");}
                    System.out.print(" ");
                    //}
                    //}
                }
            }
            System.out.println();
        }
//========================================================
        // lower part

        for (int i = 0; i < size2; i++) {
            // printing dots
            for (int j = 0; j < i; j++) {
                System.out.print(".");
            }
            // printing sides / and \
            for (int k = (size2 - i) * 2 - 1; k >= 1; k--) {
                if (k == 1 || k == (size2 - i) * 2 - 1) {
                    if(k == (size2 - i) * 2 - 1){
                        System.out.print("\\");
                        if(k==1){
                            System.out.print("/");
                            for (int j = 0; j < i; j++) {
                                System.out.print(".");
                            }
                        }
                    }
                    else{
                        System.out.print("/");
                        for (int j = 0; j < i; j++) {
                            System.out.print(".");
                        }
                    }
                }
                else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }
    }
}
