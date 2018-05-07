	(SynthDef(\fatsaw, {
		| out=0, freq = 440, amp=1, gate=1, pos=0,attack=0.01, decay=0.3, sustain=0.5, release=1, filterSpeed=100, filterFreqStart=300, filterFreqEnd=400, resonance=1, hfFilterFreq=1, hfFilterResonance=1 |
		var sig, env, filtFreq, sig2;
		env = EnvGen.kr(Env.linen(attack, sustain, release), levelScale:0.5,doneAction:2);
		sig = env*Splay.ar(LFSaw.ar(freq*[0.98,0.99,1.0,1.01,1.02],[LFNoise0.kr(2), LFNoise0.kr(1.9), LFNoise0.kr(2.1)]) + SinOsc.ar(freq*[0.98,0.99,1.0,1.01,1.02],[LFNoise0.kr(2), LFNoise0.kr(1.9), LFNoise0.kr(2.1)]));
		filtFreq = LFSaw.kr(filterSpeed,iphase:1).range(filterFreqStart,filterFreqEnd);
		sig = RLPF.ar(sig, filtFreq, resonance);
		sig = RHPF.ar(sig, hfFilterFreq, hfFilterResonance);
	2.do({
			sig = AllpassN.ar(sig, 0.050, [0.050.rand, 0.050.rand], 1);
		});


	sig = JPverb.ar(in:sig);
	sig = Mix(sig);
	sig = Pan2.ar(in:sig,pos:pos);
		Out.ar(out, amp*sig.tanh*env);
}).add;)

a = Synth(\fatsaw,[\freq,38.midicps,\attack,0.1,\sustain,0.1,\release,0.1])


a.set(\freq,40.midicps)
a.set(\resonance,0.1)
a.free
38.midinote

(
OSCdef.new(
	\particle,
	{
		|msg|
		[msg].postln;
		~scale = [38,40,43,45,55,58].midicps*4;
		~random = {rrand(400,1000);};
		~panRand = {rrand(-1.0,1.0);};
		Synth(\fatsaw,[\freq,~random,\attack,0.1,\sustain,0.1,\release,0.1,\pan,~panRand,\hfFilterResonance,0.25])
	},
	'/particle',
	nil,
	57120
))


s.plotTree