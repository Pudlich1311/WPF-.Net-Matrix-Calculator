.code

asmAdd proc    
   mov r11, 1 ;take one to r11 register
   loop1:   

         vmovups ymm0, [rcx]   ;take first parameter (a) to ymm0
         vmovups ymm1, [rdx]   ;take second parameter (b) to ymm1
         vaddps ymm3, ymm0, ymm1;add second parameter to first and store in ymm3
         vmovups [r8], ymm3;take ymm3 to r8 (c) register

         inc r11      ; Increment
         cmp r11,150000   ; Compare c11 to the limit
         jle loop1   ; Loop while less or equal
    
    ret
asmAdd endp

asmSub proc
    mov r11, 1 ;take one to r11 register
    loop1:   

         vmovups ymm0, [rcx] ;take first parameter (a) to ymm0
         vmovups ymm1, [rdx] ;take second parameter (b) to ymm1
         vsubps  ymm3, ymm0, ymm1 ;substract and store in ymm3
         vmovups [r8], ymm3 ; take ymm3 to r8 register (c)

         inc r11      ; Increment
         cmp r11,150000   ; Compare c11 to the limit
         jle loop1   ; Loop while less or equal  
    ret
asmSub endp

asmMul proc
    mov r11, 1 ;take one to r11 register
    loop1:   

         vmovups ymm0, [rcx] ;take first parameter (a) to ymm0   
         vmovups ymm1, [rdx] ;take second parameter (b) to ymm1
         vdpps ymm3, ymm0, ymm1, 11110001b ;dot product of two register with bit mask 
         cmp r9,1 ;check if r9 is 1
         jz moreVal ;jump if it is and compute the fifth value
         jmp next ;jump to next if not

         moreVal: 
             vmovups ymm5, [rcx+16] ; move next 4 values from a
             vmovups ymm6, [rdx+16] ; move next 4 values from b
             vdpps  ymm5,ymm5,ymm6, 11110001b ; dot product of the rest of values
             vaddps ymm3,ymm3,ymm5 ;add the other values to ymm3

         next:
            vmovups [r8], ymm3 ; move ymm3 to r8 register (c)       
            inc r11      ; Increment
            cmp r11,150000   ; Compare c11 to the limit
            jle loop1   ; Loop while less or equal  
    ret


          
asmMul endp

asmDummy proc
    ret
asmDummy endp



end
