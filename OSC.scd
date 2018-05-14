~n = NetAddr.new("127.0.0.1",57120);






(SynthDef(\sound,{ |f=440|
	var sig, env;
	env = EnvGen.kr(Env.linen(0.01,0.05,0.01),doneAction:2);
	sig = LFSaw.ar(f*[0.5,2],mul:rrand(1/4,1));
	sig = sig * env;
	sig = GVerb.ar(sig,300,mul:0.75);
	Out.ar(0,(sig)!2);
}).send(s);)

Synth(\sound,[\f,60.midicps])


(
OSCdef.new(
	\particle,
	{
		|msg|
		[msg].postln;
		~scale = [53,55,48].midicps*2;
		~random = {rrand(400,1000).postln;};
		Synth(\sound,[\f,~random]);
	},
	'/particle',
	nil,
	57120
))