import rhinoscriptsyntax as rs
import random

__commandname__ = "RandomColors"
#written by Clark Cheng
#email: ccheng@clarkcheng.design
def RunCommand( is_interactive ):
    def random_colors_to_objs():
        color_obj=rs.GetObjects("Select Geometry to Assign Color", preselect=True)
        if not color_obj:
            print("None selected")
            return
        else:
        
            #random color
            
            #creating list to hold geo
            random_color_obj=[]
            
            items = ("Random_Red", "False", "True"),("Random_Green", "False", "True"),("Random_Blue", "False", "True")
            results=rs.GetBoolean("Boolean options" ,items, (True,True,True))
            
            
            #random red
            if results==[True,False,False]:
                
                
                #the meat
                for obj in color_obj:
                    #generate random color
                    
                    gb=random.randint(5,255)
                    
                    color_range=(255),(gb),(gb)
                    #apply to    each individual objects
                    rs.ObjectColor(obj,color_range)
                    
                    random_color_obj.append(obj)
            #random green
            elif results==[False,True,False]:
                
                #the meat
                for obj in color_obj:
                    #generate random color
                    
                    rb=random.randint(5,255)
                    
                    color_range=(rb),(255),(rb)
                    #apply to each individual objects
                    rs.ObjectColor(obj,color_range)
                    
                    random_color_obj.append(obj)
                    
            #random blue
            elif results==[False,False,True]:
                
                #the meat
                for obj in color_obj:
                    #generate random color
                    
                    rg=random.randint(5,255)
                    
                    color_range=(rg),(rg),(255)
                    #apply to each individual objects
                    rs.ObjectColor(obj,color_range)
                    
                    random_color_obj.append(obj)
                                
                                
            elif results==[False,True, False]:
                for obj in color_obj:
                    rb=random.randint(5,255)
                    
                    color_range=rb,255,rb
                    #apply to each individual objects
                    rs.ObjectColor(obj,color_range)
                    
                    random_color_obj.append(obj)
            else:
                #the meat
                for obj in color_obj:
                    #generate random color
                    
                    rg=random.randint(0,255)
                    
                    color_range=(random.randint(0,255)),(random.randint(0,255)),(random.randint(0,255))
                    #apply to each individual objects
                    rs.ObjectColor(obj,color_range)
                    
                    random_color_obj.append(obj)
                    
                    
                    
                    
                                #number of objects
                print(len(random_color_obj)," objects were randomized with colors")
    #run the function
    random_colors_to_objs()
#RunCommand(True)