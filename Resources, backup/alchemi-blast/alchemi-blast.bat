@echo off
formatdb -i ecoli.nt -p F -o T
blastall -p blastn -d ecoli.nt -i %1 -o %2