I have developed this open source project for automatic radiation dose distribution evaluation for Varian Eclipse version 13.6 as one 
of my side projects while working clinically in Skånes University Hospital as a medical physicist on the radiotherapy department.
It is provided with the GNU 3 license, fee to use, free to modify, free to distribute, contributions must remain open source. 
No legal responsibility or warranty is provided. The project contains two parts; one script part meant for clinical use and one 
application part meant for scientific studies. 

Features of script:
Automatically matches the current plan against templates/protocols and evaluates the plan. Matching is done based on plan name 
and fractionation scheme.

Easy interface to create your own templates/protocols for your own hospital or study.

Let’s you configure for removal of prefixes in names.

Evaluates selected plan or sum of plans, will evaluate individual plans in a sums of plans at the same time.

Highlight structures of interest in custom colors.

Will let you see what structures might be misspelled (sort by hitting “2”).

Will let you see what structures that is the most critical and is not for filling your criteria (sort by hitting “3”).

Evaluates, dos at volume, volume at dose, max, -min, mean- and median dose. All in relative or absolute values mixed according
to your template.

Two views of the result are provided (alternate by hitting “4”).

Can change between plans in current course.

Work flow goes like this: hit run, hit keyboard number “2”, view the top row, hit “3” and view the top row. If the plan was all
right you are now done. 

Features of application:
Evaluates all patients from a list of their social security numbers according to a selected template/protocol. Plans are 
identified in the same manner as for the script.

Search through database for patients based on plan and optionally in some combinations of sex, creation date, age, number of 
patients wanted. (this is a rather slow process)

Can use the same templates as the script or create new collections of templates. 

Can also evaluate existing uncertainty plans for robustness investigations.

Provides detailed information and a statistical summary of the results that you can copy and continue to work with in for instance excel.

To make it easier to start I provided a ready to use script.zip folder and files of the application in the other zip folder,
just extract these. The content of the script folder should be put from eclipse/external beam planning in: tools/scripts/open directory…

The application must be put directly on a computer with Eclipse and Aria installed. 

Acknowledgements:
I want to acknowledge Fredrik Nordström (Sahlgrenska University hospital) for sharing valuable knowledge with me 
(the first version of this program required the user to write their own XML code) for significantly helping me to improve this project 
and thus acting as a mentor and friend. I also want to thanks Rex Cardan (UAB) for the information he put online about Eclipse and
acknowledge Elinore Wieslander and my colleges at Skånes University hospital for their valuable feedback of this project.

notes: only use one copy of the script. Have the same iso center shifts in your uncertainty plans, dont name nomral plans in the fashion U followed by numbers since this is the signature of an uncertainty plan.


