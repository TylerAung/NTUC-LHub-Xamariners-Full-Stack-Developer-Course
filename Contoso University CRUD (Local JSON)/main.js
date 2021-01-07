//$('input[name="genderRadios"]:checked').val();

        //% STUDENT INSERT
        $('#studentAdd').on("click", () => {
            let student = {};
            student.id = $('input').eq(0).val();
            student.name = $('input').eq(1).val();
            student.enlistedDate = $('input').eq(2).val();
            student.courseName = $("select option:selected").text();
            student.gender = $('input[name="genderRadios"]:checked').val();
            console.log(student);
            try {
                feedBack($('input').eq(0));
                feedBack($('input').eq(1));
                feedBack($('input').eq(2));
                $.post("http://localhost:3000/studentCollection", student)
                .done(res => Success(res))
                .fail(res => Error(res));
            } catch (error) {
                console.log(error);
            }  
        })

        //% COURSE INSERT
        $('#courseAdd').on("click", () => {
            let course = {};
            course.id = $('input').eq(0).val();
            course.courseName = $('input').eq(1).val();
            try {
                feedBack($('input').eq(0));
                feedBack($('input').eq(1));
                $.post("http://localhost:3000/coursesCollection", course)
                .done(res => clearForm(res))
                .fail(res => Error(res));
            } catch (error) {
                console.log(error);
            }  
        })

        // let httpGet = new Promise((res,rej)=>{

        // })

        //% CLEAR AFTER ADDING
        let Success = (res) => {
            $('input').eq(0).val("");
            $('input').eq(1).val("");
            $('input').eq(2).val("");
            $('select').val("");
            $('input[name="genderRadios"]').prop('checked', false);
            console.log("Entry Successfully Added");
            //Display();
        };

        let clearForm = (res) =>{
            $('#courseForm')[0].reset();
        }

        let Error = res => console.log(res);

        //% POPULATE COURSES DDL 
        let dropdown = $('select');
            dropdown.empty();
            dropdown.prop('selectedIndex', 0);
                const url = 'http://localhost:3000/coursesCollection';
                // Populate dropdown with list of provinces
                $.getJSON(url, function (data) {
                $.each(data, function (key, entry) {
                    dropdown.append($('<option></option>').attr('value', entry.id).text(entry.courseName));                                                                                 
        })
        });
        
        // $('form').on("focusout", ()=>{
        //     if 
        // });

        //% FEEDBACK & VALIDATION
        const feedBack = data =>{
            let feedBack = data.parent().parent().children().last();
            //conso
            //! Else Logic Not Working
            if((data.val().length >= 3)){
                console.log("This should work");
                if (feedBack.hasClass("invalid-feedback")){
                    console.log(feedBack.hasClass("invalid-feedback"));
                    feedBack.removeClass("invalid-feedback").addClass("valid-feedback");
                    feedBack.text("Validated ✓");
                }
                else{
                    feedBack.addClass("valid-feedback");
                    feedBack.text("Validated ✓");
                }        
            } else {
                console.log(data.val().length)
                 feedBack.addClass("invalid-feedback")
                 feedBack.text("Field Can't Be Empty X");
                 throw "Field is empty"
            }
        }

        // $( document ).ready(()=>{
        //     $('input').eq(0).add("focusout", feedBack($('input').eq(0)));
        //     $('input').eq(1).add("focusout", feedBack($('input').eq(1)));
        //     $('input').eq(2).add("focusout", feedBack($('input').eq(2)));
        // });
        //Display Handling
        let Display = () => {
            $.get("http://localhost:3000/studentCollection")
                .done(res => DisplayIterater(res))
                .fail(res => Error(res));

            
        };

        let DisplayIterater = (res) => {
            let i = 1;
            
            for (item of res) {
                const container = document.createElement("tr");
                if(!!(i % 2 == 0)) {
                    container.classList.add("bg-primary");
                }
                const Scol1 = document.createElement("td");
                Scol1.classList.add("data");
                const Scol2 = document.createElement("td");
                Scol2.classList.add("data");
                const Scol3 = document.createElement("td");
                Scol3.classList.add("data");
                const Scol4 = document.createElement("td");
                Scol4.classList.add("data");
                const Scol5 = document.createElement("td");
                Scol5.classList.add("data");
                const Scol6 = document.createElement("td");
                Scol1.textContent = item.id;
                Scol2.textContent = item.name;
                Scol3.textContent = item.gender;
                Scol4.textContent = item.courseName;
                Scol5.textContent = item.enlistedDate;
                //Scol6.innerHTML = `<input id="aEdit" type="button" onclick="editStudent(${item.id})" value="Edit"/> <input id="aDELETE" type="button" onclick="deleteStudent(${item.id})" value="DELETE"/>`;
                Scol6.innerHTML = `<button class="studsave">Save</button> <button class="studedit">Edit</button> <button class="studdelete">Delete</button>`
                container.appendChild(Scol1);
                container.appendChild(Scol2);
                container.appendChild(Scol3);
                container.appendChild(Scol4);
                container.appendChild(Scol5);
                container.appendChild(Scol6);
                $('.studTbl').append(container);
                i++;
            }
            };
                
        let courseDisplay = () => {
            $.get("http://localhost:3000/coursesCollection")
                .done(res => CourseIterater(res))
                .fail(res => Error(res));
        };

        let CourseIterater = (res) => {
            let i = 1;
            
            for (item of res) {
                const container = document.createElement("tr");
                if(!!(i % 2 == 0)) {
                    container.classList.add("bg-primary");
                }
                const Scol1 = document.createElement("td");
                Scol1.classList.add("data");
                const Scol2 = document.createElement("td");
                Scol2.classList.add("data");
                const Scol3 = document.createElement("td");
                Scol1.textContent = item.id;
                Scol2.textContent = item.courseName;
                Scol3.innerHTML = `<button class="coursesave">Save</button> <button class="courseedit">Edit</button> <button class="coursedelete">Delete</button>`
                container.appendChild(Scol1);
                container.appendChild(Scol2);
                container.appendChild(Scol3);
                $('.courseTbl').append(container);
                i++;
            }
            };
          
        //% Student Create Edit Input & Unhide Save Btn
        $(document).on('click', '.studedit', function() {
        $(this).parent().siblings('td.data').each(function() {
            var content = $(this).html();
            $(this).html('<input value="' + content + '" />');
        });
        // $(this). To disable later
        $(this).siblings('.studsave').show();
        $(this).siblings('.studdelete').hide();
        $(this).hide();
        });

        //% Student Save Edited Entry
        
        $(document).on('click', '.studsave', function() {
        
            const student = {};
            let row = $(this).parent().parent();
            //console.log("Earlier C ", row.children());
            //console.log(row.children());
            console.log("Name ", row.children().children().eq(1).val()); //Name           
            console.log("Gender ", row.children().children().eq(2).val());
            console.log("Course ", row.children().children().eq(3).val());
            console.log("Enlist ", row.children().children().eq(4).val());
            
            student.id = row.children().children().eq(0).val();
            student.name = row.children().children().eq(1).val();
            student.enlistedDate = row.children().children().eq(4).val()
            student.courseName = row.children().children().eq(3).val();
            student.gender = row.children().children().eq(2).val();
            console.log(student);

           $.ajax({
            url: "http://localhost:3000/studentCollection/" + student.id,
            type: "PUT",
            data: student,
            success: Success
        });
        
        

        $('input').each(function() {
            var content = $(this).val();
            $(this).html(content);
            $(this).contents().unwrap();
        });

        $(this).siblings('.studedit').show();
        $(this).siblings('.studdelete').show();
        $(this).hide();
        

        });
        
         //% Course Create Edit Input & Unhide Save Btn
         $(document).on('click', '.courseedit', function() {
            $(this).parent().siblings('td.data').each(function() {
                var content = $(this).html();
                $(this).html('<input value="' + content + '" />');
            });
            // $(this). To disable later
            $(this).siblings('.coursesave').show();
            $(this).siblings('.coursedelete').hide();
            $(this).hide();
            });
        //% Course Save Edited Entry
        $(document).on('click', '.coursesave', function() {
        
            const course = {};
            let row = $(this).parent().parent();
            //console.log("Earlier C ", row.children());
            //console.log(row.children());
           // console.log("Name ", row.children().children().eq(1).val()); //Name           
            
            course.id = row.children().children().eq(0).val();
            course.courseName = row.children().children().eq(1).val();
            
            console.log(course);

           $.ajax({
            url: "http://localhost:3000/coursesCollection/" + course.id,
            type: "PUT",
            data: course,
            success: Success
        });

        

        $('input').each(function() {
            var content = $(this).val();
            $(this).html(content);
            $(this).contents().unwrap();
        });

        $(this).siblings('.courseedit').show();
        $(this).siblings('.coursedelete').show();
        $(this).hide();
        

        });


        //% Course Delete Entry
        $(document).on('click', '.coursedelete', function() {

            const id = this.parentElement.parentElement.firstElementChild.textContent;
            //console.log("ID ", this.parentElement.parentElement.firstElementChild.textContent);
            //row.children().eq(0).html()

            $.ajax({
                type: 'DELETE',
                url: 'http://localhost:3000/coursesCollection/' + id,
                success: Success,
                error: Error
            });

        $(this).parents('tr').remove();
        });

        //! Need create Delete for Student Entry too
        //* http://localhost:3000/studentCollection/

       //# COUNTER
       const studCount = () => {
            $.get("http://localhost:3000/studentCollection")
            .done(res=> {
                $("#studentCount").text(res.length);
            })
            .fail(res => Error(res));
          };

        const courseCount = () => {
            $.get("http://localhost:3000/coursesCollection")
                .done(res=> {
                    $("#courseCount").text(res.length);
                })
                .fail(res => Error(res));

                //array.filter(value => value.age === 23).length; GENDER COUNT
        };
    
       let genderCount = ()=>{
            $.get("http://localhost:3000/studentCollection")
            .done(res=> {
                let m =0, f=0;
                for(item of res){
                    let gender = item.gender.toLowerCase();
                    if(gender === "male"){
                        m++
                    }
                    else{
                        f++
                    }
                }
                $("#genderCount").html(`No of Male Students: ${m}<br>No of Female Students: ${f}`);
            })
            .fail(res => Error(res));
       }

       let courseGenderBreakdown = ()=>{
            $.get("http://localhost:3000/coursesCollection")
            .done(res=> {
                for(item of res){
                    let course = item.courseName.toLowerCase();
                    let m =0, f=0;
                        $.get("http://localhost:3000/studentCollection")
                        .done(respond=> {
                            for(itemIN of respond){
                                let gender = itemIN.gender.toLowerCase();
                                //console.log(gender);
                                let courseIN = itemIN.courseName.toLowerCase();
                                    if(gender === "male" && course === courseIN){
                                        m++
                                        //console.log(m)
                                    }
                                    else if(gender === "female" && course === courseIN){
                                        f++
                                        //NOTE International clients in UK or SO, doesn't like F or 0 or falsy
                                        //console.log(f)
                                    }
                            }
                            // console.log(`${course} has Male = ${m}`);
                            // console.log(`${course} has Female = ${f}`);
                            $("#courseSexCount").append(`<span>${course.toUpperCase()} : ${m} Male & ${f} Female </span><br>`)
                            
                        })
                        .fail(res => Error(res));                   
                }
                
            })
            .fail(res => Error(res));
       }
       //% Document on Load
       $( document ).ready(()=>{
           let title = $(document).attr('title')
           if (title === "Home"){
            studCount()
            courseCount()
            genderCount()
            courseGenderBreakdown()
           }
           else if(title === "Student Management Form"){
            Display();
           }
           else if(title === "Course Management Form"){
            courseDisplay();
           }
       })