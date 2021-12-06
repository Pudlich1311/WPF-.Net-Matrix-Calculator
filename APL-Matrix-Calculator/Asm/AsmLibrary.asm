.code

asmAdd proc    
   mov r11, 1 ;take one to r11 register
   loop1:   
         vmovups ymm0, [rcx]   ;take first parameter (a) to ymm0
         vmovups ymm1, [rdx]   ;take second parameter (b) to ymm1
         vaddps ymm3, ymm0, ymm1;add second parameter to first and store in ymm3
         vmovups [r8], ymm3;take ymm3 to r8 (c) register
         
         ;second version wit xmm
         ;movups xmm0, [rcx] ;take first parameter (a) to xmm0
         ;movups xmm1, [rdx] ;take second parameter (b) to xmm1
         ;addps xmm0, xmm1 ;add second parameter to first
         ;movups [r8], xmm0 ;take xmm0 to r8 (c) register
    
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
         vsubps  ymm3, ymm0, ymm1 ;substract second parameter to first and store in ymm3
         vmovups [r8], ymm3 ; take ymm3 to r8 register (c)

         ;second version with xmm
         ;movups xmm0, [rcx] ;take first parameter A to xmm0
         ;movups xmm1, [rdx] ;take second parameter B to xmm1
         ;subps  xmm0, xmm1 ;substract second parameter to first and store in xmm0
         ;movups [r8], xmm0 ;take xmm0 to r8 register
    
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
         vdpps ymm3, ymm0, ymm1, 11111111b ;dot product of tho register with bit mask what pairs should be added
         vmovups [r8], ymm3 ; move ymm3 to r8 register (c)

         ;second version with xmm
         ;movups xmm0, [rcx] ;take first parameter (a) to xmm0
         ;movups xmm1, [rdx] ;take second parameter (b) to xmm1
         ;dpps xmm0,xmm1, 11111111b dot product with bit mask what pairs should be added  
         ;movups [r8], xmm0 ;take xmm0 to r8 register (c)
    
         inc r11      ; Increment
         cmp r11,150000   ; Compare c11 to the limit
         jle loop1   ; Loop while less or equal  
    ret
asmMul endp

asmDummy proc
    ret
asmDummy endp



end
