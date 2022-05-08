namespace Guardians

open WebSharper
open WebSharper.Sitelets
open WebSharper.UI
open WebSharper.UI.Server
open Giraffe.ViewEngine


type EndPoint =
    | [<EndPoint "/">] About
    | [<EndPoint "/character">] Characters
    | [<EndPoint "/wawes">] Wawes
    | [<EndPoint "/social">] Social
    
module Templating =
    open WebSharper.UI.Html

    type MainTemplate = Templating.Template<"Main.html">
   

    // Compute a menubar where the menu item for the given endpoint is active
    let MenuBar (ctx: Context<EndPoint>) endpoint : Doc list =
        let ( => ) txt act =
             li [if endpoint = act then yield attr.``class`` "active"] [
                a [attr.href (ctx.Link act)] [text txt]
             ]
        [
            "About us" => EndPoint.About
            "Characters" => EndPoint.Characters
            "Wawe version" => EndPoint.Wawes
            "Social" => EndPoint.Social
            
        ]
    
     

    let Main ctx action (title: string) (body: Doc list) =
        Content.Page(
            MainTemplate()
                .Title(title)
                .MenuBar(MenuBar ctx action)
                .Body(body)
                .Doc()
        )

module Site =
    open WebSharper.UI.Html

    let HomePage ctx =
        Templating.Main ctx EndPoint.About "About us" [
                      h1 [] [text "Welcome, Guardians!"]
                      div [] [
                              p [] [ text "On this page you can get detailed information about the story, characters and achievements of our upcoming project: Light - Dance Death! "]
                              h3 [] [text "About us:"]
                              p [] [ text "The project was started in the early 2010s by Wawe Derbi, as a Sonic fan comic. (Yes, it was a bunch of fan characters at the start)"]
                              p [] [text "Frujenga joined this universe in 2015 and together they started a reboot version as a ''novel''. If you interested about the original story, you can read some interesting fact below the ''wave version'' tab"]
                              p [] [text "But in 2019 they stopped this version - after about 34 published and 1 never posted chapter - and started to work on a new back story and an original design.  "]
                              p [] [text "And now they try to make video games about the story."]
                              hr[][]
                              div[attr.id("obj")] [
                                  h1[] [text "Our current projects:"]
                                  h2[] [text "Light - Dance Death"]
                                  p [] [text "Genre: fantasy, Action Adventure, Misc"]
                                  p [][text "Platform: Pc"]
                                  p [][text "Expected appearance: end of 2023"]
                                  p [][text "First demo expected appearance: end of 2022 "]
                                  p [][text "Summary: What would you do for survival? After an unfortunate accident, Molliana Emily Shine, briefly Molly, is forced to ally with the god of death, giving her a special task: Molly must find someone to replace her, who should have been dead for a long time, otherwise the girl will have to stay in the underworld. As Molly searches for the person, she pays attention to strange things around her family, history..."]
                                  
                                  
                              ]
                              img[attr.src("https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/30fc971e-6af8-44ad-8445-8344811b9a24/df4zroc-fdbb6fc2-e8b8-4b85-bf35-38a53925d749.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzMwZmM5NzFlLTZhZjgtNDRhZC04NDQ1LTgzNDQ4MTFiOWEyNFwvZGY0enJvYy1mZGJiNmZjMi1lOGI4LTRiODUtYmYzNS0zOGE1MzkyNWQ3NDkucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.8TjW4lj1LjcKXJ_501uiepDscZ6gmoK5QFl8URj1kQU"); attr.id("pic")][]
                                  
                           
                              
                      ]
                  ]
            
        

    let CharacterPage ctx =
        Templating.Main ctx EndPoint.About "Characters" [
        hr[][]
        div[] [
            h2[] [text "Molliana Emily Shine"]
            p [] [text "The main character"]
            
        ]
        hr[][]

        div[] [
                   h2[] [text "Sonja Light"]
                   p [] [text "Molly's mother."]
                   
               ]
        hr[] []
        div[] [
                    h2[] [text "Nate Shine"]
                    p [] [text "Molly's death father"]
          
             ]
        hr[] []
        div[] [
                    h2[] [text "Break Paradis"]
                    p [] [text "Molly's stepfather"]
          
             ]
        hr[] []

        div[] [
                    h2[] [text "Holly Shine"]
                    p [] [text "Molly's twin sister"]
          
             ]
        hr[] []

        div[] [
                    h2[] [text "Lou Light"]
                    p [] [text "Molly's grandfather"]
          
             ]
        hr[] []
        div[] [
                    h2[] [text "Myra Light"]
                    p [] [text "Molly's grandmother"]
          
             ]
      
        hr[] []
        div[] [
                    h2[] [text "Dewei"]
                    p [] [text "Myra's advisable and dearest friend."]
          
             ]







        div[] [
            h2[] [text "Shuasang"]
            p [] [text "Goddess of Life"]
            p [][text "Shuasang is the strongest god of the four gods of harmony. She was the last one who was created by the Goddess of Fate."]
            p [][text "Before her death, she was one of the first to come up with their abilities and became a mighty mage. It was rumored that she could inflict a fatal wound on her opponent with a single tiny petal."]
            p [][text "Unfortunately, due to an illness, even a simple injury was able to bleed for days, this was used against her when she was killed. After her death, she was able to return as the goddess of life, who became an extremely popular person among mortals and gods because of her mind, beauty and pleasant appearance."]
            p [][text "Her ability to make and destroy souls and with her stick called the Tree of Life can kill anyone in an instant - it is rumored that the previous god of death died by her .."]
            
            
        ]

        div[] [
                   h2[] [text "Issy"]
                   p [] [text "Goddess of Space"]
                   p [][text "Issy is the youngest god of the four gods of harmony."]
                   p [][text "At that time, during a war, she and those like her were taken en masse to destruction, from which no one escaped. She survived because she was saved by the previous god of space."]
                   p [][text "Issy has the ability to manipulate space so she can easily defend herself."]
                 
                   
                   
               ]

        div[] [
            h2[] [text "Wei"]
            p [] [text "God of Time"]
            p [][text "Wei is the one who really enjoy his job as the god of time "]
            p [][text "Sometime as a mortal because of a serious illness, he has time for things he really wanted. In spite of that, he was grateful for every day he could live."]
            p [][text "To express his gratitude, he often visited the Temple of the Sun God, who eventually fell in love with Wei. After Wei's death The Sun God helped him became the God of Time. "]
            p [][text "Wei's abilities include manipulating time. This makes it easy to manage the past, present and future."]
            
            
        ]

        div[] [
            h2[] [text "Hallow"]
            p [] [text "God of Death"]
            p [][text "Hallow is a very interesting person. Almost nothing can be known about his past."]
            p [][text "And he will be the one, who giving Molly the special task....."]
        
            
            
        ]

            
        ]
        

    let WawesPage ctx =
        Templating.Main ctx EndPoint.About "Wawe version" [
        img [attr.src("https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/89af81a7-0587-48d5-a917-9427ab1c60c4/d4vdvoa-fed944d6-a8bf-474d-8d67-c6c307cd8958.png/v1/fill/w_900,h_675,q_80,strp/always_walk_on_by_sonamy_love3_d4vdvoa-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9Njc1IiwicGF0aCI6IlwvZlwvODlhZjgxYTctMDU4Ny00OGQ1LWE5MTctOTQyN2FiMWM2MGM0XC9kNHZkdm9hLWZlZDk0NGQ2LWE4YmYtNDc0ZC04ZDY3LWM2YzMwN2NkODk1OC5wbmciLCJ3aWR0aCI6Ijw9OTAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.DTzk8jAJe1LeWS8jDqPJ1KGzXKsYGhbAM5OA4cexfpY"); attr.width("300px"); attr.height("250")][]

        div[attr.id("obj")] [ 
             h2[] [text "In the original version, the main characters were five boys: Sony, Shon, Troy, Antony and Joker. The five of them sought to protect the universe from all danger."]
             p [] [text "Interesting facts:"]
             p [][text "In the original project, she was a female protagonist with the same name as the writer’s nickname. In later versions, Wawe became Molliana’s best friend during her high school years."]
             p [][text "Sony's original name is Sonixa Paradis, who is the son of Break Paradis. From this, Sonixa is Molliana's step-brother."]
             p [][text "There were already surnames in the original version, which is rare in the Sonic universe. Joker is the only one who doesn't have that. "]
             p [][text "Two of the five boys — Shon and Sonixa — are cousins on the paternal line."]
             p [][text "Troy Gracia will be in the Light."]
             p [][text "Mythology was not yet present in this story, but magic and abilities had already appeared."]
             p [][text "The names of Hungarian-related cities, such as Miskolc, appear in the story. The five boys also studied in one of the institutions of the town."]
             p [][text "Some of the characters are members of lmbtq. Sony is bisexual, while Joker is a gay character."]
             p [][text "Joker is considered a girl, but he is a boy."]
             p [][text "A lot of elements - including talismans - have been moved to the new version, only slightly expanded."]
         ]
         
        div[attr.id("obj")] [ 
                     img [attr.src("https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/30fc971e-6af8-44ad-8445-8344811b9a24/df51v0j-cfbe112e-e94a-4331-a0fe-67671a4678d9.jpg/v1/fill/w_945,h_665,q_75,strp/116780609_299783204622039_8359708068268842892_n_by_frujenga_df51v0j-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NjY1IiwicGF0aCI6IlwvZlwvMzBmYzk3MWUtNmFmOC00NGFkLTg0NDUtODM0NDgxMWI5YTI0XC9kZjUxdjBqLWNmYmUxMTJlLWU5NGEtNDMzMS1hMGZlLTY3NjcxYTQ2NzhkOS5qcGciLCJ3aWR0aCI6Ijw9OTQ1In1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.wa809nkZlzKolUCUG_3gSs4dk71IOEg9OwoMmfap2KA"); attr.width("300px"); attr.height("250")][]
    ]
 
        ]

    let SocialPage ctx =
        Templating.Main ctx EndPoint.About "Social" [
        div[attr.id("obj")][
            a[attr.href("https://www.youtube.com/channel/UC4MgheTrF9RJW6lzV9WwmkQ")][text "Youtube Channel"]      
            br[][]
            br[][]
            a[attr.href("https://www.instagram.com/_frujenga_/")][text "Frujenga's instagram"]    
            br[][]
            a[attr.href("https://www.deviantart.com/frujenga")][text "Frujenga's deviantart"]      
            br[][]
            a[attr.href("https://twitter.com/frujenga")][text "Frujenga's twitter"]      
            br[][]
            br[][]
            a[attr.href("https://www.instagram.com/wawe_ciel/")][text "Wawe's instagram"]      
            br[][]
            a[attr.href("https://www.deviantart.com/sonamy-love3")][text "Wawe's deviantart"]      
            br[][]
            a[attr.href("https://twitter.com/cielo_espania")][text "Wawe's twitter"]      
         ]
        div[attr.id("obj")][
            iframe[attr.src("https://www.youtube.com/embed/WyO9zB1LPr4"); attr.title("Land of Gods - Official OST")][]
            iframe[attr.src("https://www.youtube.com/embed/Hl2yKjCzkBo"); attr.title("Bastard Og Consenza")][]
            iframe[attr.src("https://www.youtube.com/embed/KMaRADHAjW8"); attr.title("Molliana First Look")][]
            
        
        
        ]
            ]
            
        
   
    

    [<Website>]
    let Main =
        Application.MultiPage (fun ctx endpoint ->
            match endpoint with
            | EndPoint.About -> HomePage ctx
            | EndPoint.Characters -> CharacterPage ctx
            | EndPoint.Wawes -> WawesPage ctx
            | EndPoint.Social -> SocialPage ctx
            
            
        )
