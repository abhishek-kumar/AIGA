Alchemi BLAST
=============

Author: Akshay Luther (akshayl@cs.mu.oz.au)


Introduction
------------

Searching for similarities between biological sequences is the principal means by which bioinformatics contributes to our understanding of biology. Of the various informatics tools developed to accomplish this task, the most widely used is BLAST. 

This document outlines the Alchemi BLAST demonstration and outlines the grid-enabling of BLAST (http://www.ncbi.nih.gov/BLAST/) for Alchemi.


Running the Demo
----------------

Note: The Alchemi Job Submitter, 'alchemi_jsub.exe' is a program that allows one to submit tasks, create tasks, add jobs to tasks and get finished jobs.

Follow these steps to run the demo:

* To connect to a grid, run alchemi_jsub with the details of the Alchemi Manager and security credentials. For example, to connect to a default installation of a local Alchemi grid:

    alchemi_jsub localhost 9000 user user

* Submit the task defined in 'blast-demo.xml':
    
    submittask blast-demo.xml

* Get the finished jobs using the alias for the task returned in the previous step. For example:

    getfinishedjobs 1001


Example:

    ---
    C:\alchemi-blast>alchemi_jsub localhost 9000 user user

    Alchemi [.NET Grid Computing Framework]
    http://www.alchemi.net

    Job Submitter v0.8.0
    Connected to Manager at localhost:9000

    > submittask blast-demo.xml
    -- Task submitted (alias = 1001).

    > getfinishedjobs 1001
    -- Got 3 job(s).
    -- Wrote file .\seq0.out for job 0.
    -- Wrote file .\seq1.out for job 1.
    -- Wrote file .\seq2.out for job 2.

    > exit

    C:\alchemi-blast>
    ---


Explanation
-----------

In the demo, the standalone BLAST executable, 'blastall.exe' is used to run a BLAST search for three nucleotide sequences against the 'ecoli.nt' database. These nucleotide sequences (inputs) are contained in 'seq0.txt', 'seq1.txt' and 'seq2.txt'.

On a single machine, one would need to run 'formatdb.exe' against 'ecoli.nt' to format the database in a form that is usable by 'blastall.exe'. This would be done using the following command:

    formatdb -i ecoli.nt -p F -o T

To perform the actual BLAST search, the following command would need to be used:

    blastall -p blastn -d ecoli.nt -i <inputfile> -o <outputfile>

To grid enable BLAST for Alchemi, the first step is to create a wrapper program around these two commands that accepts parameters for input and output files. This is done via a simple batch file, 'alchemi-blast.bat'. Please see the contents of this file to understand this step.

Next, a task file is created that describes the jobs to be executed on the grid, 'blast-demo.xml'. Please see the contents of this file to understand this step.



