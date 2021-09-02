


function jmgModal(id, data, ok, cancel, input) {
	data = data || {};
	id = "modal-" + id;
	if (document.getElementById(id) == null) {
		var d = document.createElement("div");
		d.className = "jmgmodal";
		d.id = id;
		var p = document.createElement("div");
		p.className = "panel";
		var t = document.createElement("div");
		t.className = "title";
		var cl = document.createElement("div");
		cl.className = "close";
		cl.innerHTML = '&times;';
		cl.addEventListener('click', function (ev) {
			ev.preventDefault();
			var dTop = this.parentNode.parentNode;
			dTop.classList.remove("visible");
			dTop.querySelector(".panel .content").innerHTML = '';
		});
		var ct = document.createElement("div");
		ct.className = "content";
		var f = document.createElement("div");
		f.className = "footer";
		p.appendChild(t); p.appendChild(cl); p.appendChild(ct); p.appendChild(f);
		d.appendChild(p);
		document.body.appendChild(d);
	}
	var mod = document.getElementById(id),
		p = mod.querySelector(".panel"),
		t = mod.querySelector(".panel .title"),
		ct = mod.querySelector(".panel .content"),
		f = mod.querySelector(".panel .footer");
	if (f == null) {
		mod.classList.remove("nofooter");
		var f = document.createElement("div");
		f.className = "footer";
		p.appendChild(f);
	}
	t.innerHTML = data.title || '';
	ct.innerHTML = data.content || '';
	f.innerHTML = '';
	if (!isNaN(data.width)) p.style.maxWidth = data.width + 'px';
	if (!isNaN(data.height)) p.style.maxHeight = data.height + 'vh';
	if (ok && ok.length > 1) {
		var param = { value: null };
		if (input && input.length > 0) {
			var ph = document.createElement("p");
			ph.className = "action";
			var txt = document.createElement("input");
			txt.className = "action";
			txt.setAttribute("placeholder", input[0]);
			txt.addEventListener('keydown', function (ev) {
				if (ev.keyCode == 13 || ev.key == "Enter") {
					ev.preventDefault();
					mod.classList.remove("visible");
					ok[1](param.value);
				}
			});
			ph.appendChild(txt); ct.appendChild(ph);
			param = ct.querySelector("p.action > input.action");
			setTimeout(function () {
				param.focus();
			}, 100);
		}
		var bOk = document.createElement("button");
		bOk.className = "action";
		bOk.innerHTML = ok[0];
		bOk.addEventListener('click', function (ev) {
			ev.preventDefault();
			mod.classList.remove("visible");
			ok[1](param.value);
		});
		f.appendChild(bOk);
	}
	if (cancel && cancel.length > 1) {
		var bCancel = document.createElement("button");
		bCancel.className = "action";
		bCancel.innerHTML = cancel[0];
		bCancel.addEventListener('click', function (ev) {
			ev.preventDefault();
			mod.classList.remove("visible");
			cancel[1]();
		});
		f.appendChild(bCancel);
	}
	if (f.innerHTML == '') {
		p.removeChild(f);
		mod.classList.add("nofooter");
	}
	setTimeout(function () {
		mod.classList.add("visible");
	}, 50);
}
