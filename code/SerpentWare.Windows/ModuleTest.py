### EXAMPLE PYTHON MODULE
# Define some variables:
numberone = 1
ageofqueen = 78

# define some functions
def printhello():
    print "hello"
    
def timesfour(input):
    print input * 4
    
# define a class
class Piano:
    def __init__(self):
        self.type = "Pianola"
        self.height = 3
        self.price = 1200
        self.age = 8
	
    def printdetails(self):
        print "This piano is a/an " + str(self.height) + " foot",
        print self.type, "piano, " + str(self.age), "years old and costing " + str(self.price) + " dollars."
 