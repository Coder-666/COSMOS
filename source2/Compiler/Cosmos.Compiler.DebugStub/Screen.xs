﻿Group DebugStub

procedure Cls2 {
	# VidBase
    ESI = $B8000
    
BeginLoop:
	# Text
    AL = $00
    ESI[0] = AL
    ESI + 1

	# Colour
    AL = $0A
    ESI[0] = AL
    ESI + 1

	# End of Video Area
	# VidBase + 25 * 80 * 2 = B8FA0
	#ESI < $B8FA0
	#if < goto BeginLoop
	# If (ESI < $B8FA0) goto .BeginLoop
}